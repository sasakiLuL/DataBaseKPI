using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Filters;
using RGR.Dal.Repos.BaseRepo;
using RGR.Dal.Repos;

NpgsqlConnection npgsqlConnection = new NpgsqlConnection()
{
    ConnectionString = "host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345"
};

ClassRepo classesRepo = new(npgsqlConnection);

var a = classesRepo.FindFullClassInfo(Filter<Class>.Value(c => c.ClassId).Between(0, 5));

a.ToList().ForEach(e => Console.WriteLine($"{e.Entity.ClassId}, {e.Entity.MaxParticipants}, {e.ParticipantCount}, {e.CourseName}"));

Console.WriteLine();

GymRepo gymRepo = new(npgsqlConnection);

var b = gymRepo.FindAllWithUserAndCoachesCount();

b.ToList().ForEach(e => Console.WriteLine($"{e.Entity.GymName}, {e.UsersCount}, {e.CoachesCount}"));

return;