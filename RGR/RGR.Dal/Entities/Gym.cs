using RGR.Dal.ORM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Entities
{
    public class Gym
    {
        [DataNames("gym_id")] public int GymId { get; set; }
        [DataNames("gym_name")] public string GymName { get; set; } = null!;
        [DataNames("description")] public string Description { get; set; } = string.Empty;
        [DataNames("gym_type")] public string GymType { get; set; } = null!;
        [DataNames("address")] public string Address { get; set; } = null!;
        [DataNames("home_page")] public string HomePage { get; set; } = string.Empty;
        [DataNames("phone_number")] public string PhoneNumber { get; set; } = null!;
        [DataNames("email")] public string Email { get; set; } = string.Empty;
        public IEnumerable<ContractTerms> ContractsTerms { get; set; } = new List<ContractTerms>();
        public IEnumerable<Coach> Coaches { get; set; } = new List<Coach>();
        public IEnumerable<User> Participants { get; set; } = new List<User>();
    }
}
