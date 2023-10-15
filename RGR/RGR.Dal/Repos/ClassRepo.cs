using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class ClassRepo : BaseRepo<Class>
    {
        public ClassRepo(NpgsqlConnection connection) : base(connection) {}


    }
}
