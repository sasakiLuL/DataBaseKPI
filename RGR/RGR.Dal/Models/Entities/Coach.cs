using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Models.Entities
{
    [Table("coaches")]
    public class Coach
    {
        [Key]
        [Column("coach_id")]
        public long CoachId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; } = null!;

        [Column("last_name")]
        public string LastName { get; set; } = null!;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("employment_date")]
        public DateTime EmploymentDate { get; set; }

        [Column("gym_id")]
        public long GymId { get; set; }

    }
}
