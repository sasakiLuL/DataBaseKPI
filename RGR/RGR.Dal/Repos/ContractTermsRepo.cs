using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class ContractTermsRepo : BaseRepo<Class>
    {
        public ContractTermsRepo(NpgsqlConnection connection) : base(connection) { }
    }
}
