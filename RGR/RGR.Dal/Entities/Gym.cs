using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAppoi.Models.Entities
{
    public class Gym
    {
        public int GymId { get; set; }
        public string GymName { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public string GymType { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string HomePage { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<ContractTerms> ContractsTerms { get; set; } = new List<ContractTerms>();
        public IEnumerable<Coach> Coaches { get; set; } = new List<Coach>();
        public IEnumerable<User> Participants { get; set; } = new List<User>();
    }
}
