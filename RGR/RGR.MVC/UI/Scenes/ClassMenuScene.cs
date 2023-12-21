using NpgsqlTypes;
using RGR.Dal.Models;
using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class ClassMenuScene : TableScene
    {
        public override SceneType Type => SceneType.ClassMenu;

        private readonly Controller<Class> _controller;

        public ClassMenuScene(UISettings settings, Controller<Class> controller) : base(settings)
        {
            _controller = controller;
        }

        public override SceneType Render()
        {
            switch (GetPrompt("classes"))
            {
                case "Find all":
                    _controller.PrintAllEntities();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ClassMenu;

                case "Add":
                    _controller.AddEntity(
                        new Class(
                        AnsiConsole.Prompt(
                            new TextPrompt<int>($"Enter [{Settings.HeaderColor}]maximal participants[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        new NpgsqlRange<DateTime>
                        (
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
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]course id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    ));
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ClassMenu;

                case "Update":
                    _controller.UpdateEntity(
                        new Class()
                        {
                            ClassId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter class[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                            MaxParticipants = AnsiConsole.Prompt(
                            new TextPrompt<int>($"Enter [{Settings.HeaderColor}]maximal participants[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                            CourseId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]course id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                            Duration = new NpgsqlRange<DateTime>
                        (
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
                        )
                        });
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ClassMenu;

                case "Delete":
                    _controller.DeleteEntity( new Class()
                    {
                        ClassId = AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter class[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    });
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ClassMenu;

                default:
                    AnsiConsole.Clear();
                    return SceneType.StartMenu;
            };
        }
    }
}
