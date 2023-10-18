using Npgsql;

namespace RGR.MVC.UI
{
    public interface ISceneBuilder
    {
        IEnumerable<Scene> BuildScenes(UISettings settings, NpgsqlConnection connection);
    }
}