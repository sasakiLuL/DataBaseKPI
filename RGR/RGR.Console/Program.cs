using Npgsql;
using RGR.Dal.Entities;
using RGR.Dal.Repos.BaseRepo;

NpgsqlConnection npgsqlConnection = new NpgsqlConnection()
{
    ConnectionString = "host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345"
};
BaseRepo<Class> classRepo = new(npgsqlConnection);

classRepo.Delete(14);