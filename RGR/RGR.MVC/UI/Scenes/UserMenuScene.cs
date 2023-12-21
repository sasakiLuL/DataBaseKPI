using RGR.Dal.Models;
using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class UserMenuScene : TableScene
    {
        public override SceneType Type => SceneType.UserMenu;

        private readonly Controller<User> _controller;

        public UserMenuScene(UISettings settings, Controller<User> controller) : base(settings)
        {
            _controller = controller;
        }

        public override SceneType Render()
        {
            switch (GetPrompt("users"))
            {
                case "Find all":
                    _controller.PrintAllEntities();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.UserMenu;

                case "Add":
                    _controller.AddEntity( new() {
                        FirstName = AnsiConsole.Prompt(
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
                        LastName= AnsiConsole.Prompt(
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
                        Sex= AnsiConsole.Prompt(
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
                        DateOfBirth= AnsiConsole.Prompt(
                            new TextPrompt<DateOnly>($"Enter [{Settings.HeaderColor}]date of birth[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        Address= AnsiConsole.Prompt(
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
                        Phone= AnsiConsole.Prompt(
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
                        Email= AnsiConsole.Prompt(
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
                        ) }
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.UserMenu;

                case "Update":
                    _controller.UpdateEntity( new() { 
                        UserId= AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        FirstName = AnsiConsole.Prompt(
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
                        LastName= AnsiConsole.Prompt(
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
                        Sex= AnsiConsole.Prompt(
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
                        DateOfBirth= AnsiConsole.Prompt(
                            new TextPrompt<DateOnly>($"Enter [{Settings.HeaderColor}]date of birth[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        Address= AnsiConsole.Prompt(
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
                        Phone= AnsiConsole.Prompt(
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
                        Email= AnsiConsole.Prompt(
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
                        ) }
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.UserMenu;

                case "Delete":
                    _controller.DeleteEntity( new() {
                        UserId= AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter user[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )}
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.UserMenu;

                case "Back":
                    AnsiConsole.Clear();
                    return SceneType.StartMenu;

                default:
                    AnsiConsole.Clear();
                    return SceneType.StartMenu;
            };
        }
    }
}
