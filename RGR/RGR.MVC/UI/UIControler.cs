using Microsoft.EntityFrameworkCore;
using RGR.Dal;
using System.Text;

namespace RGR.MVC.UI
{
    public enum SceneType
    {
        StartMenu,
        GenerateMenu,
        ClassMenu,
        CoachMenu,
        ContractMenu,
        ContractTermsMenu,
        CourseMenu,
        GymMenu,
        UserMenu,
        Closed
    }
    public sealed class UIControler
    {
        public SceneType CurrentScene { get; private set; }

        public UISettings Settings { get; private set; }

        private Dictionary<SceneType, Scene> Scenes { get; set; }

        public UIControler(ISceneBuilder builder)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            DbContextOptionsBuilder<Lab2Context> optionsBuilder = new();

            optionsBuilder.UseNpgsql("User ID=postgres;Password=pass12345;Host=localhost;Port=5433;Database=Lab2;");

            Lab2Context context = new Lab2Context(optionsBuilder.Options);

            CurrentScene = SceneType.StartMenu;
            Scenes = new Dictionary<SceneType, Scene>();
            Settings = new UISettings();

            foreach (Scene scene in builder.BuildScenes(Settings, context))
            {
                Scenes.Add(scene.Type, scene);
            }
        }

        public void Run()
        {
            while (CurrentScene != SceneType.Closed) 
            {
                CurrentScene = Scenes[CurrentScene].Render();
            }
        }
    }
}
