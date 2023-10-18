using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class UserMenuScene : TableScene
    {
        public override SceneType Type => SceneType.UserMenu;

        public UserController Controller { get; set; }

        public UserMenuScene(UISettings settings, UserController controller) : base(settings)
        {
            Controller = controller;
            var MenuChoicesList = MenuChoices.ToList();
            MenuChoicesList.Insert(0, $"Find users contracts count[{Settings.UnactiveColor}] (by date range)[/]");
            MenuChoices = MenuChoicesList.ToArray();
        }

        public override SceneType Render()
        {
            switch (GetPrompt())
            {
                case "Find all":
                    Controller.PrintAllUsers();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                case "Add":
                    Controller.AddUser(
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]first name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]last name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<int>($"Enter [{Settings.HeaderColor}]sex[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v <= 2 && v >= 1)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]date of birth[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]address[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 256)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 256");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]phone number[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 16)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 16");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]email[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(v =>
                            {
                                if (v.Length <= 256)
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
                    Controller.UpdateUser(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]first name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]last name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<int>($"Enter [{Settings.HeaderColor}]sex[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v <= 2 && v >= 1)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]date of birth[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]address[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 256)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 256");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]phone number[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 16)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 16");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]email[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(v =>
                            {
                                if (v.Length <= 256)
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
                    Controller.DeleteUser(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter user[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ClassMenu;

                case "Back":
                    AnsiConsole.Clear();
                    return SceneType.StartMenu;

                default:
                    DateTime firstInput = AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter first[{Settings.HeaderColor}] id[/] bound:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        );
                    DateTime secondInput = AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter second[{Settings.HeaderColor}] id[/] bound:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(s =>
                            {
                                if (s > firstInput)
                                    return ValidationResult.Success();
                                else
                                    return ValidationResult.Error("First value greater than second!");
                            })
                        );
                    Controller.PrintUsersContractsByDateOfBirth(firstInput, secondInput);
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.UserMenu;
            };
        }
    }
}
