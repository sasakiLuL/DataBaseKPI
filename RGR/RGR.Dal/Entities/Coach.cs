using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAppoi.Models.Entities
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public byte[] EmploymentDate { get; set; } = null!;
        public int GymId { get; set; }
        public Gym Gym { get; set; } = null;
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();
    }
}
