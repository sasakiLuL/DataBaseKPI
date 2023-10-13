using Npgsql;
using RGR.Dal.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class CoachRepo : BaseRepo<Coach>
    {
        public CoachRepo(NpgsqlConnection connection) : base(connection) { }

    }
}
