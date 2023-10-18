using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class ClassMenuScene : TableScene
    {
        public override SceneType Type => SceneType.ClassMenu;

        public ClassController Controller { get; set; }

        public ClassMenuScene(UISettings settings, ClassController controller) : base(settings)
        {
            Controller = controller;
            var MenuChoicesList = MenuChoices.ToList();
            MenuChoicesList.Insert(0, $"Find full class info [{Settings.UnactiveColor}](by id range)[/]");
            MenuChoices = MenuChoicesList.ToArray();
        }

        public override SceneType Render()
        {
            switch (GetPrompt())
            {
                case "Find All":
                    Controller.PrintAllClasses();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ClassMenu;

                case "Add":
                    Controller.AddClass(
                        AnsiConsole.Prompt(
                            new TextPrompt<int>($"Enter [{Settings.HeaderColor}]maximal participants[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]course id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]start time[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]end time[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ClassMenu;

                case "Update":
                    Controller.UpdateClass(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter class[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<int>($"Enter [{Settings.HeaderColor}]maximal participants[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]course id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]start time[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<DateTime>($"Enter [{Settings.HeaderColor}]end time[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ClassMenu;

                case "Delete":
                    Controller.DeleteClass(
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
                    return SceneType.ClassMenu;

                case "Back":
                    AnsiConsole.Clear();
                    return SceneType.StartMenu;

                default:
                    long firstInput = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter first[{Settings.HeaderColor}] id[/] bound:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        );
                    long secondInput = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter second[{Settings.HeaderColor}] id[/] bound:")
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
                    Controller.PrintFullClassInfoByClassIdRange(firstInput, secondInput);
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ClassMenu;
            };
        }
    }
}
