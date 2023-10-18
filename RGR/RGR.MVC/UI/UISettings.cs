using Spectre.Console;

namespace RGR.MVC.UI
{
    public class UISettings
    {
        public Color ActiveColor => Color.Grey93;

        public Color UnactiveColor => Color.Grey74;

        public Color HeaderColor => Color.HotPink;

        public Color SelectedColor => Color.PaleVioletRed1;

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