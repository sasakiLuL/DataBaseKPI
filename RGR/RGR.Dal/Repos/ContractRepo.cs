using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class ContractRepo : BaseRepo<Contract>
    {
        public ContractRepo(NpgsqlConnection connection) : base(connection) { }
    }
}

