using RGR.Dal.Models;
using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class ContractMenuScene : TableScene
    {
        public override SceneType Type => SceneType.ContractMenu;

        private readonly Controller<Contract> _controller;

        public ContractMenuScene(UISettings settings, Controller<Contract> controller) : base(settings)
        {
            _controller = controller;
        }

        public override SceneType Render()
        {
            switch (GetPrompt("contracts"))
            {
                case "Find all":
                    _controller.PrintAllEntities();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractMenu;

                case "Add":
                    _controller.AddEntity( new() {
                        TransactionTime = AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]transaction time[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        PaymentMethod = AnsiConsole.Prompt(
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
                        UserId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]user id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        ContractTermId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]contract terms id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ) }
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractMenu;

                case "Update":
                    _controller.UpdateEntity( new() {
                        ContractId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        TransactionTime = AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]transaction time[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        PaymentMethod = AnsiConsole.Prompt(
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
                        UserId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]user id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        ContractTermId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]contract terms id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ) }
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractMenu;

                case "Delete":
                    _controller.DeleteEntity( new() {
                        ContractId=  AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter class[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ) }
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractMenu;

                default:
                    AnsiConsole.Clear();
                    return SceneType.StartMenu;
            };
        }
    }
}
