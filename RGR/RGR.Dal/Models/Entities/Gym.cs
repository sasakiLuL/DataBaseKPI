using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Models.Entities
{
    [Table("gyms")]
    public class Gym
    {
        [Key]
        [Column("gym_id")]
        public long GymId { get; set; }

        [Column("gym_name")]
        [MaxLength(100)]
        public string GymName { get; set; } = null!;

        [Column("description")]
        [MaxLength(2000)]
        public string? Description { get; set; } = string.Empty;

        [Column("gym_type")]
        [MaxLength(50)]
        public string? GymType { get; set; } = null!;

        [Column("address")]
        [MaxLength(256)]
        public string Address { get; set; } = null!;

        [Column("home_page")]
        [MaxLength(256)]
        public string? HomePage { get; set; } = string.Empty;

        [Column("phone_number")]
        [MaxLength(16)]
        public string PhoneNumber { get; set; } = null!;

        [Column("email")]
        [MaxLength(256)]
        public string? Email { get; set; } = string.Empty;
    }
}
