namespace RGR.Dal.Entities
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
    }
}
