namespace RGR.Dal.Entities
{
    public class ContractTerms
    {
        public int ContractTermId { get; set; }
        public string ContractName { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int GymId { get; set; }
    }
}
