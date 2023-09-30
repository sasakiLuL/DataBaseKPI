using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RGR.Dal.ORM;

namespace RGR.Dal.Entities
{
    public class User
    {
        [DataNames("user_id")] public int UserId { get; set; }
        [DataNames("first_name")] public string FirstName { get; set; } = null!;
        [DataNames("last_name")] public string LastName { get; set; } = null!;
        [DataNames("sex")] public int Sex { get; set; }
        [DataNames("date_of_birth")] public DateTime DateOfBirth { get; set; }
        [DataNames("address")] public string Address { get; set; } = null!;
        [DataNames("phone")] public string PhoneNumber { get; set; } = null!;
        [DataNames("email")] public string Email { get; set; }
        public IEnumerable<Contract> Contracts { get; set; } = new List<Contract>();
        public IEnumerable<Gym> Gyms { get; set; } = new List<Gym>();
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();
    }
}
