using Npgsql;
using RGR.Dal;
using RGR.Dal.Entities;
using RGR.Dal.Filters;
using RGR.Dal.Filters.BinaryFilters;
using static RGR.Dal.QueryOperations;

NpgsqlConnection connection = new("host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345");

DbSet<Gym> gyms = new(connection);

var g = gyms.Query().Select(e => new { e.GymId, e.GymName, e.Email })
                    .Where(e => Equal(e.GymName, 1))
                    .Execute();

//g.ToList().ForEach(e => Console.WriteLine($"{e}"));

return;