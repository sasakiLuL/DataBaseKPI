using RGR.Dal.Models;
using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class GymMenuScene : TableScene
    {
        public override SceneType Type => SceneType.GymMenu;

        private readonly Controller<Gym> _controller;

        public GymMenuScene(UISettings settings, Controller<Gym> controller) : base(settings)
        {
            _controller = controller;
        }

        public override SceneType Render()
        {
            switch (GetPrompt("gyms"))
            {
                case "Find all":
                    _controller.PrintAllEntities();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                case "Add":
                    _controller.AddEntity( new() {
                        GymName= AnsiConsole.Prompt(
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
                        Address = AnsiConsole.Prompt(
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
                        HomePage = AnsiConsole.Prompt(
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
                        Phone = AnsiConsole.Prompt(
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
                        Email = AnsiConsole.Prompt(
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
                        )}
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                case "Update":
                    _controller.UpdateEntity( new() {
                         GymId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        GymName = AnsiConsole.Prompt(
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
                         Address=AnsiConsole.Prompt(
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
                        HomePage= AnsiConsole.Prompt(
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
                        Phone= AnsiConsole.Prompt(
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
                        Email = AnsiConsole.Prompt(
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
                        ) }
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                case "Delete":
                    _controller.DeleteEntity( new() {
                        GymId= AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter gym[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ) }
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.GymMenu;

                default:
                    AnsiConsole.Clear();
                    return SceneType.StartMenu;
            };
        }
    }
}
