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
        public string FirstName { get; set; } = null!;

        [Column("last_name")]
        public string LastName { get; set; } = null!;

        [Column("sex")]
        public int Sex { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [Column("address")]
        public string Address { get; set; } = null!;

        [Column("phone")]
        public string PhoneNumber { get; set; } = null!;

        [Column("email")]
        public string? Email { get; set; } = null;
    }
}
