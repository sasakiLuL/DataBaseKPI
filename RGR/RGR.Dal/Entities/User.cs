namespace RGR.Dal.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; }
        public IEnumerable<Contract> Contracts { get; set; } = new List<Contract>();
        public IEnumerable<Gym> Gyms { get; set; } = new List<Gym>();
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();
    }
}
