using StrategyBank.Core.Strategies.Interfaces;
using TransactionProcessor.Core.Entities;

namespace StrategyBank.Core.Strategies;

public class DefaultStrategy : ITransactionStrategy
{
    public bool IsApplicable(Transaction transaction) => true;

    public void ApplyFee(Transaction transaction) =>
        transaction.Fee = 1.5m;
}