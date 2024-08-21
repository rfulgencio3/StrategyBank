using StrategyBank.Core.Enums;
using StrategyBank.Core.Strategies.Interfaces;
using TransactionProcessor.Core.Entities;

namespace StrategyBank.Core.Strategies;

public class ArgentinaTransactionStrategy : ITransactionStrategy
{
    public bool IsApplicable(Transaction transaction) =>
        transaction.SourceCountry == Country.Argentina;

    public void ApplyFee(Transaction transaction)
    {
        throw new InvalidOperationException("Transactions from Argentina are not allowed.");
    }
}
