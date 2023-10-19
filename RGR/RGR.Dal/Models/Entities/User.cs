using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Models.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public long UserId { get; set; }

        [Column("first_name")]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Column("last_name")]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Column("sex")]
        [MaxLength(2)]
        public int Sex { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [Column("address")]
        [MaxLength(256)]
        public string Address { get; set; } = null!;

        [Column("phone")]
        [MaxLength(16)]
        public string PhoneNumber { get; set; } = null!;

        [Column("email")]
        [MaxLength(256)]
        public string? Email { get; set; } = null;
    }
}
