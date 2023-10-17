using Npgsql;
using RGR.Dal.Filters;
using RGR.Dal.Models.Entities;
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

var controler = new ClassController(new ClassRepo(npgsqlConnection), new ClassView());

return;