using TransactionProcessor.Core.Entities;

namespace StrategyBank.Core.Strategies.Interfaces;

public interface ITransactionStrategy
{
    bool IsApplicable(Transaction transaction);
    void ApplyFee(Transaction transaction);
}