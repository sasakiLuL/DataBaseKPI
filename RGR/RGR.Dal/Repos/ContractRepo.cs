using Npgsql;
using RGR.Dal.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class ContractRepo : BaseRepo<Class>
    {
        public ContractRepo(NpgsqlConnection connection) : base(connection) { }
    }
}

