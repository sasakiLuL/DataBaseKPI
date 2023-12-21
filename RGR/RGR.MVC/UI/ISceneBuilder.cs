using RGR.Dal;

namespace RGR.MVC.UI
{
    public interface ISceneBuilder
    {
        IEnumerable<Scene> BuildScenes(UISettings settings, Lab2Context context);
    }
}