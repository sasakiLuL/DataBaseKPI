using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class UserRepo : BaseRepo<Class>
    {
        public UserRepo(NpgsqlConnection connection) : base(connection) { }
    }
}
