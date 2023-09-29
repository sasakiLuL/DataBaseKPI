using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace GAppoi.Models.Entities
{
    public class Contract
    {
        public int ContractId { get; set; }
        public byte[] TransactionTime { get; set; } = null!;
        public string PaymentMethod { get; set; } = null!;
        public int? ParticipantId { get; set; } = null;
        public User User { get; set; } = null;
        public int? ContractTermsId { get; set; } = null;
        public ContractTerms ContractTerms { get; set; } = null;
    }
}
