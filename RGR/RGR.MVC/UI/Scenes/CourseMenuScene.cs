using RGR.Dal.Models;
using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class CourseMenuScene : TableScene
    {
        public override SceneType Type => SceneType.CourseMenu;

        private readonly Controller<Course> _controller;

        public CourseMenuScene(UISettings settings, Controller<Course> controller) : base(settings)
        {
            _controller = controller;
        }

        public override SceneType Render()
        {
            switch (GetPrompt("courses"))
            {
                case "Find all":
                    _controller.PrintAllEntities();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.CourseMenu;

                case "Add":
                    _controller.AddEntity( new() {
                         CourseName=AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]course name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ) }
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.CourseMenu;

                case "Update":
                    _controller.UpdateEntity( new() {
                        CourseId= AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        CourseName= AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]course name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        )}
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.CourseMenu;

                case "Delete":
                    _controller.DeleteEntity( new() {
                        CourseId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter class[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )}
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.CourseMenu;

                default:
                    AnsiConsole.Clear();
                    return SceneType.StartMenu;
            };
        }
    }
}


