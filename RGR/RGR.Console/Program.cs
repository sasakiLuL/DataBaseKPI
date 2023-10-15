using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Filters;
using RGR.Dal.Repos.BaseRepo;

NpgsqlConnection npgsqlConnection = new NpgsqlConnection()
{
    ConnectionString = "host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345"
};

BaseRepo<User> usersRepo = new(npgsqlConnection);

var a = usersRepo.Find(Filter<User>.Value(u => u.FirstName).Like("W%"));

a.ToList().ForEach(e => Console.WriteLine(e.FirstName));

return;