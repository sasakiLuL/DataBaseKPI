using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GAppoi.Models.Entities
{
    public class ContractTerms
    {
        public int ContractTermId { get; set; }
        public string ContractName { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public IEnumerable<Contract> Contracts { get; set; } = new List<Contract>();
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();
        public int GymId { get; set; }
        public Gym Gym { get; set; } = null;
    }
}
