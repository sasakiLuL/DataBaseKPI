using RGR.MVC.Controlers.BaseControler;
using Spectre.Console;

namespace RGR.MVC.UI
{
    public abstract class TableScene : Scene
    {
        protected string[] MenuChoices { get; set; }

        public TableScene(UISettings settings) : base(settings)
        {
            MenuChoices = new[] {
                    "Find all",
                    "Add",
                    "Update",
                    "Delete",
                    "Generate",
                    "Back" };
        }

        protected string GetPrompt()
        {
            return AnsiConsole.Prompt
            (
                new SelectionPrompt<string>()
                {
                    DisabledStyle = Settings.ActiveColor,
                    HighlightStyle = Settings.SelectedColor
                }
                .Title($"[{Settings.HeaderColor}]Select operation![/]")
                .AddChoices(MenuChoices)
            );
        }

    }
}
