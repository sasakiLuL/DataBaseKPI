namespace RGR.Dal.Entities
{
    public class Contract
    {
        public int ContractId { get; set; }
        public DateTime TransactionTime { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public int? UserId { get; set; } = null;
        public int? ContractTermsId { get; set; } = null;
    }
}
