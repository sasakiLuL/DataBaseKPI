using Npgsql;
using RGR.Dal.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class GymRepo : BaseRepo<Class>
    {
        public GymRepo(NpgsqlConnection connection) : base(connection) { }
    }
}