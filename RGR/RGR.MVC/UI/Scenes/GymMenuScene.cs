using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class GymMenuScene : TableScene
    {
        public override SceneType Type => SceneType.GymMenu;

        public GymController Controller { get; set; }

        public GymMenuScene(UISettings settings, GymController controller) : base(settings)
        {
            Controller = controller;
            var MenuChoicesList = MenuChoices.ToList();
            MenuChoicesList.Insert(0, $"Find gyms with users and coaches count[{Settings.UnactiveColor}] (like expression)[/]");
            MenuChoices = MenuChoicesList.ToArray();
        }

        public override SceneType Render()
        {
            switch (GetPrompt())
            {
                case "Find all":
                    Controller.PrintAllGyms();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                case "Add":
                    Controller.AddGym(
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]gym name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(gym =>
                            {
                                if (gym.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]description[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(desc =>
                            {
                                if (desc.Length <= 2000)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 2000");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]gym type[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(type =>
                            {
                                if (type.Length <= 50)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 50");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]address[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(add =>
                            {
                                if (add.Length <= 256)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 256");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]home page[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(page =>
                            {
                                if (page.Length <= 256)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 256");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]phone number[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(phone =>
                            {
                                if (phone.Length <= 16)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 16");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]email[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(phone =>
                            {
                                if (phone.Length <= 256)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 256");
                            })
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                case "Update":
                    Controller.UpdateGym(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]gym name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(gym =>
                            {
                                if (gym.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]description[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(desc =>
                            {
                                if (desc.Length <= 2000)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 2000");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]gym type[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(type =>
                            {
                                if (type.Length <= 50)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 50");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]address[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(add =>
                            {
                                if (add.Length <= 256)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 256");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]home page[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(page =>
                            {
                                if (page.Length <= 256)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 256");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]phone number[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(phone =>
                            {
                                if (phone.Length <= 16)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 16");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]email[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(phone =>
                            {
                                if (phone.Length <= 256)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 256");
                            })
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                case "Delete":
                    Controller.DeleteGym(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter gym[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                case "Back":
                    AnsiConsole.Clear();
                    return SceneType.StartMenu;

                case "Generate":
                    Controller.GenerateRecords(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter records[{Settings.HeaderColor}] count[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                default:
                    string input = AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]like[/] expression:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        );
                    Controller.PrintGymUsersAndCoachesCountByName(input);
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;
            };
        }
    }
}
