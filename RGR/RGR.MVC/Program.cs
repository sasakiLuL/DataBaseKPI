using RGR.MVC.UI;
using Npgsql;

NpgsqlConnection npgsqlConnection = new NpgsqlConnection()
{
    ConnectionString = "host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345"
};

UIControler uiControler = new UIControler(new RgrSceneBuilder(), npgsqlConnection);

uiControler.Run();

return;