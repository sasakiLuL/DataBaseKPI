using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class GymRepo : BaseRepo<Class>
    {
        public GymRepo(NpgsqlConnection connection) : base(connection) { }
    }
}