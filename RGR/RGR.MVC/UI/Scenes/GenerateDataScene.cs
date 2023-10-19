using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class GenerateDataScene : Scene
    {
        public GenerateDataScene(UISettings settings) : base(settings) {}

        public override SceneType Type => SceneType.GenerateMenu;

        public override SceneType Render()
        {
            //switch (AnsiConsole.Prompt
            //(
            //    //new SelectionPrompt<string>()
            //    //{
            //    //    DisabledStyle = Settings.ActiveColor,
            //    //    HighlightStyle = Settings.SelectedColor
            //    //}
            //    //.Title($"[{Settings.HeaderColor}]Select table in which data will create![/]")
            //    //.AddChoices(new[] {
            //    //    "users",
            //    //    "classes"
            //    //    //""
            //    //})
            //    //.UseConverter(Settings.SceneTypeConverter)
            //))
            //{
                
            //}

            return SceneType.StartMenu;
        }
    }
}
