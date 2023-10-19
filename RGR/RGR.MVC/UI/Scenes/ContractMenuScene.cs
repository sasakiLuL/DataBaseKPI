using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class ContractMenuScene : TableScene
    {
        public override SceneType Type => SceneType.ContractMenu;

        public ContractController Controller { get; set; }

        public ContractMenuScene(UISettings settings, ContractController controller) : base(settings)
        {
            Controller = controller;
        }

        public override SceneType Render()
        {
            switch (GetPrompt())
            {
                case "Find all":
                    Controller.PrintAllContracts();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractMenu;

                case "Add":
                    Controller.AddContract(
                        AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]transaction time[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]payment method[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 300)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 300");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]user id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]contract terms id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractMenu;

                case "Update":
                    Controller.UpdateContract(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]transaction time[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]payment method[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 300)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 300");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]user id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]contract terms id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractMenu;

                case "Delete":
                    Controller.DeleteContract(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter class[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractMenu;

                case "Generate":
                    Controller.GenerateRecords(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter records[{Settings.HeaderColor}] count[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractMenu;

                default:
                    return SceneType.StartMenu;
            };
        }
    }
}
