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
        public string GymName { get; set; } = null!;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("gym_type")]
        public string GymType { get; set; } = null!;

        [Column("address")]
        public string Address { get; set; } = null!;

        [Column("home_page")]
        public string HomePage { get; set; } = string.Empty;

        [Column("phone_number")]
        public string PhoneNumber { get; set; } = null!;

        [Column("email")]
        public string Email { get; set; } = string.Empty;
    }
}
