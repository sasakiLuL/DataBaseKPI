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
                new GymMenuScene(settings, new GymController(new GymRepo(connection), new GymView())),
            };
        }
    }
}
