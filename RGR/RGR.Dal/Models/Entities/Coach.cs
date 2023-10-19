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
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Column("last_name")]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Column("description")]
        [MaxLength(2000)]
        public string? Description { get; set; } = string.Empty;

        [Column("employment_date")]
        public DateTime EmploymentDate { get; set; }

        [Column("gym_id")]
        [ForeignKey(nameof(Gym))]
        public long GymId { get; set; }

    }
}
