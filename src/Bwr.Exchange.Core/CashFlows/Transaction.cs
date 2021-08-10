using Abp.Domain.Values;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bwr.Exchange.CashFlows
{
    [Owned]
    public class Transaction : ValueObject
    {
        public Transaction() { }
        public Transaction(
            int transactionId,
            TransactionType type
            )
        {
            TransactionId = transactionId;
            Type = type;
        }
        public int TransactionId { get; }
        public TransactionType Type { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TransactionId;
            yield return Type;
        }
    }
}
