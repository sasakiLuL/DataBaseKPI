using Npgsql;
using RGR.Dal.Entities;
using RGR.Dal.Repos.BaseRepo;

NpgsqlConnection npgsqlConnection = new NpgsqlConnection()
{
    ConnectionString = "host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345"
};

BaseRepo<User> usersRepo = new(npgsqlConnection);

var users = usersRepo.FindAll();

users.ToList().ForEach(Console.WriteLine);