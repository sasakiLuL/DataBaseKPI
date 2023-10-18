using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class CourseMenuScene : TableScene
    {
        public override SceneType Type => SceneType.CourseMenu;

        public CourseController Controller { get; set; }

        public CourseMenuScene(UISettings settings, CourseController controller) : base(settings)
        {
            Controller = controller;
        }

        public override SceneType Render()
        {
            switch (GetPrompt())
            {
                case "Find all":
                    Controller.PrintAllCourses();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.CourseMenu;

                case "Add":
                    Controller.AddCourse(
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]course name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.CourseMenu;

                case "Update":
                    Controller.UpdateCourse(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!"),
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]course name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.CourseMenu;

                case "Delete":
                    Controller.DeleteCourse(
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
                    return SceneType.CourseMenu;

                default:
                    return SceneType.StartMenu;
            };
        }
    }
}


