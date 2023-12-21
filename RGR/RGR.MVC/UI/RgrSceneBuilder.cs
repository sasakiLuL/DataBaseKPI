using RGR.Dal;
using RGR.Dal.Models;
using RGR.MVC.Controlers;
using RGR.MVC.UI.Scenes;

namespace RGR.MVC.UI
{
    public class RgrSceneBuilder : ISceneBuilder
    {
        public IEnumerable<Scene> BuildScenes(UISettings settings, Lab2Context context)
        {
            return new List<Scene>() 
            { 
                new StartMenuScene(settings),
                new ClassMenuScene(settings, new Controller<Class>(context)),
                new CoachMenuScene(settings, new Controller<Coach>(context)),
                new ContractMenuScene(settings, new Controller<Contract>(context)),
                new ContractTermsMenuScene(settings, new Controller<ContractsTerm>(context)),
                new CourseMenuScene(settings, new Controller<Course>(context)),
                new GymMenuScene(settings, new Controller<Gym>(context)),
                new UserMenuScene(settings, new Controller<User>(context))
            };
        }
    }
}
