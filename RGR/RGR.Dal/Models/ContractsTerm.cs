using System;
using System.Collections.Generic;

namespace RGR.Dal.Models;

public partial class ContractsTerm
{
    public ContractsTerm()
    {

    }

    public ContractsTerm(long contractTermsId, string contractName, decimal price, string? description, long gymId)
    {
        ContractTermsId = contractTermsId;
        ContractName = contractName;
        Price = price;
        Description = description;
        GymId = gymId;
    }

    public long ContractTermsId { get; set; }

    public string ContractName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public long GymId { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Gym Gym { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
