using TransactionProcessor.Core.Entities;

namespace StrategyBank.Core.Repositories;

public interface ITransactionRepository
{
    void Add(Transaction transaction);
    Transaction GetById(Guid id);
}
