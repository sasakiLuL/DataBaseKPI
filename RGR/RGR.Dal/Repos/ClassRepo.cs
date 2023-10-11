using Npgsql;
using RGR.Dal.Entities;
using RGR.Dal.Repos.BaseRepo;
using System.Data;

namespace RGR.Dal.Repos
{
    public class ClassRepo : BaseRepo<Class>
    {
        public ClassRepo(NpgsqlConnection connection) : base(connection) {}
    }
}
