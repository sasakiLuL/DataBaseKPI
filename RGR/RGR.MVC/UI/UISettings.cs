using Spectre.Console;

namespace RGR.MVC.UI
{
    public class UISettings
    {
        public Color ActiveColor => Color.NavajoWhite1;

        public Color UnactiveColor => Color.DarkOliveGreen3_2;

        public Color HeaderColor => Color.Aquamarine1_1;

        public Color SelectedColor => Color.Aquamarine3;

        public Func<SceneType, string> SceneTypeConverter =>
            (type) =>
                type switch 
                { 
                    SceneType.ClassMenu => "classes",
                    SceneType.CoachMenu => "coaches",
                    SceneType.ContractMenu => "contracts",
                    SceneType.ContractTermsMenu => "contract_terms",
                    SceneType.CourseMenu => "courses",
                    SceneType.GymMenu => "gyms",
                    SceneType.UserMenu => "users",
                    _ => "Close"
                };
    }
}