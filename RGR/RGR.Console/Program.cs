using Npgsql;
using RGR.Dal;
using RGR.Dal.Entities;

NpgsqlConnection connection = new("host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345");

DbSet<Gym> gyms = new(connection);

var g = gyms.Query().Select(e => new { e.GymId, e.GymName })
                    .Where(e => e.GymName)
                    .Execute();

g.ToList().ForEach(e=> Console.WriteLine($"{e}"));

return;