using System;
using System.Collections.Generic;

namespace RGR.Dal.Models;

public partial class Contract
{
    public Contract()
    {

    }

    public Contract(long contractId, DateTime transactionTime, string paymentMethod, long userId, long contractTermId)
    {
        ContractId = contractId;
        TransactionTime = transactionTime;
        PaymentMethod = paymentMethod;
        UserId = userId;
        ContractTermId = contractTermId;
    }

    public long ContractId { get; set; }

    public DateTime TransactionTime { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public long UserId { get; set; }

    public long ContractTermId { get; set; }

    public virtual ContractsTerm ContractTerm { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
