using Npgsql;
using RGR.Dal;
using RGR.Dal.Entities;
using RGR.Dal.Filters.BinaryFilters;
using static RGR.Dal.QueryOperations;

NpgsqlConnection connection = new("host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345");

DbSet<Gym> gyms = new(connection);

/*
var g = gyms.Query().Select(e => new { e.GymId, e.GymName })
                    .Where(e => Or(Equal(e.GymId, 1), Equal(e.GymId, 1)))
                    .Execute();

g.ToList().ForEach(e=> Console.WriteLine($"{e}"));
*/

Console.WriteLine(Equal(2, 1).FilterString);
Console.WriteLine(Or(2, 1).FilterString);

return;