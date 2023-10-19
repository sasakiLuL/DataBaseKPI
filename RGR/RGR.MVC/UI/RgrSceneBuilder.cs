using Npgsql;
using RGR.Dal.Repos;
using RGR.MVC.Controlers;
using RGR.MVC.UI.Scenes;
using RGR.MVC.Views;

namespace RGR.MVC.UI
{
    public class RgrSceneBuilder : ISceneBuilder
    {
        public IEnumerable<Scene> BuildScenes(UISettings settings, NpgsqlConnection connection)
        {
            return new List<Scene>() 
            { 
                new StartMenuScene(settings),
                new ClassMenuScene(settings, new ClassController(new ClassRepo(connection), new ClassView())),
                new CoachMenuScene(settings, new CoachController(new CoachRepo(connection), new CoachView())),
                new ContractMenuScene(settings, new ContractController(new ContractRepo(connection), new ContractView())),
                new ContractTermsMenuScene(settings, new ContractTermsController(new ContractTermsRepo(connection), new ContractTermsView())),
                new CourseMenuScene(settings, new CourseController (new CourseRepo(connection), new CourseView())),
                new GymMenuScene(settings, new GymController(new GymRepo(connection), new GymView())),
                new UserMenuScene(settings, new UserController(new UserRepo(connection), new UserView()))
            };
        }
    }
}
