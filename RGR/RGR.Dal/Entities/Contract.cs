﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Entities
{
    [Table("contracts")]
    public class Contract
    {
        [Key]
        [Column("contract_id")]
        public int ContractId { get; set; }

        [Column("transaction_time")]
        public DateTime TransactionTime { get; set; }

        [Column("payment_method")]
        public string PaymentMethod { get; set; } = null!;

        [Column("user_id")]
        public int? UserId { get; set; } = null;

        [Column("contract_terms_id")] 
        public int? ContractTermsId { get; set; } = null;
    }
}