namespace RGR.MVC.UI
{
    public abstract class Scene
    {
        public UISettings Settings { get; set; }

        public abstract SceneType Type { get; }

        public Scene(UISettings settings) 
        {
            Settings = settings;
        }

        public abstract SceneType Render();
    }
}
