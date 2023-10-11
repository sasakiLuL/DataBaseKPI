namespace RGR.Dal.Entities
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public DateTime EmploymentDate { get; set; }
        public int GymId { get; set; }
    }
}
