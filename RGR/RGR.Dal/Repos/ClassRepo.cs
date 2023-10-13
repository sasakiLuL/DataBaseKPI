using Npgsql;
using RGR.Dal.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class ClassRepo : BaseRepo<Class>
    {
        public ClassRepo(NpgsqlConnection connection) : base(connection) {}
    }
}
