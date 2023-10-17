using Npgsql;
using RGR.Dal.Repos;
using RGR.MVC.Controlers;
using RGR.MVC.Views;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

NpgsqlConnection npgsqlConnection = new NpgsqlConnection()
{
    ConnectionString = "host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345"
};

var userControler = new UserController(new UserRepo(npgsqlConnection), new UserView());

userControler.PrintAllUsers();

userControler.AddUser("Sasha", "Kryvko", 1, new DateTime(2004, 04, 27), "westadts", "+392032", null);

userControler.PrintAllUsers();

userControler.UpdateUser(10, "Sasha", "Kryvko", 1, new DateTime(2004, 04, 27), "westadts", "+392032", "sashakrivko75@gmail.com");

userControler.PrintAllUsers();

userControler.DeleteUser(10);

userControler.PrintAllUsers();

return;