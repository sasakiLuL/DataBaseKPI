using RGR.Dal.ORM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Entities
{
    public class Coach
    {
        [DataNames("coach_id")] public int CoachId { get; set; }
        [DataNames("first_name")] public string FirstName { get; set; } = null!;
        [DataNames("last_name")] public string LastName { get; set; } = null!;
        [DataNames("description")] public string Description { get; set; } = string.Empty;
        [DataNames("employment_date")] public byte[] EmploymentDate { get; set; } = null!;
        [DataNames("gym_id")] public int GymId { get; set; }
        public Gym Gym { get; set; } = null;
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();
    }
}
