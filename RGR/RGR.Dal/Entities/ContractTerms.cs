using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RGR.Dal.ORM;

namespace RGR.Dal.Entities
{
    public class ContractTerms
    {
        [DataNames("contract_terms_id")] public int ContractTermId { get; set; }
        [DataNames("contract_name")] public string ContractName { get; set; } = null!;
        [DataNames("price")] public decimal Price { get; set; }
        [DataNames("description")] public string Description { get; set; } = string.Empty;
        public IEnumerable<Contract> Contracts { get; set; } = new List<Contract>();
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();
        [DataNames("gym_id")] public int GymId { get; set; }
        public Gym Gym { get; set; } = null;
    }
}
