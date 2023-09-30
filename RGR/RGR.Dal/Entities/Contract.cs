using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using RGR.Dal.ORM;

namespace RGR.Dal.Entities
{
    public class Contract
    {
        [DataNames("contract_id")] public int ContractId { get; set; }
        [DataNames("transaction_time")] public byte[] TransactionTime { get; set; } = null!;
        [DataNames("payment_method")] public string PaymentMethod { get; set; } = null!;
        [DataNames("user_id")] public int? UserId { get; set; } = null;
        public User User { get; set; } = null;
        [DataNames("contract_terms_id")] public int? ContractTermsId { get; set; } = null;
        public ContractTerms ContractTerms { get; set; } = null;
    }
}
