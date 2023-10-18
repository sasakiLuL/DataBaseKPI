using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class StartMenuScene : Scene
    {

        public StartMenuScene(UISettings settings) : base(settings) { }

        public override SceneType Type => SceneType.StartMenu;

        public override SceneType Render()
        {
            return AnsiConsole.Prompt
            (
                new SelectionPrompt<SceneType>()
                {
                    DisabledStyle = Settings.ActiveColor,
                    HighlightStyle = Settings.SelectedColor
                }
                .Title($"[{Settings.HeaderColor}]Select table to work with![/]")
                .AddChoices(new[]
                {
                    SceneType.ClassMenu,
                    SceneType.CoachMenu,
                    SceneType.ContractMenu,
                    SceneType.ContractTermsMenu,
                    SceneType.CourseMenu,
                    SceneType.GymMenu,
                    SceneType.UserMenu,
                    SceneType.Closed
                })
                .UseConverter(Settings.SceneTypeConverter)
            );
        }
    }
}
