using Abp.Domain.Values;
using System.Collections.Generic;

namespace Bwr.Exchange.CashFlows
{
    public class Transaction : ValueObject
    {
        public Transaction(
            int transactionId,
            TransactionType type
            )
        {
            TransactionId = transactionId;
            Type = type;
        }
        public int TransactionId { get; private set; }
        public TransactionType Type { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TransactionId;
            yield return Type;
        }
    }
}
