using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class CoachRepo : BaseRepo<Coach>
    {
        public CoachRepo(NpgsqlConnection connection) : base(connection) { }

    }
}
