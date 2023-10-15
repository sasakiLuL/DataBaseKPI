using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Filters;
using RGR.Dal.Repos.BaseRepo;

NpgsqlConnection npgsqlConnection = new NpgsqlConnection()
{
    ConnectionString = "host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345"
};

BaseRepo<Class> classesRepo = new(npgsqlConnection);

var a = classesRepo.FindAll();

a.ToList().ForEach(e => Console.WriteLine(e.ClassId));

return;