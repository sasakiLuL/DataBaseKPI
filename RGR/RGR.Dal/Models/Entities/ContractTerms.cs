using System.ComponentModel.DataAnnotations;
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
        [MaxLength(100)]
        public string ContractName { get; set; } = null!;

        [Column("price")]
        public decimal Price { get; set; }

        [Column("description")]
        [MaxLength(2000)]
        public string? Description { get; set; } = string.Empty;

        [Column("gym_id")]
        [ForeignKey(nameof(Gym))]
        public long GymId { get; set; }
    }
}
