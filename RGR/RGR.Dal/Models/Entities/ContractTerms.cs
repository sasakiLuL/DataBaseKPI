﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Models.Entities
{
    [Table("contracts_terms")]
    public class ContractTerms
    {
        [Key]
        [Column("contract_terms_id")]
        public long ContractTermId { get; set; }

        [Column("contract_name")]
        public string ContractName { get; set; } = null!;

        [Column("price")]
        public decimal Price { get; set; }

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("gym_id")]
        public long GymId { get; set; }
    }
}