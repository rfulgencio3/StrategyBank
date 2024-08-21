using StrategyBank.Core.Repositories;
using StrategyBank.Infrastructure.Data;
using TransactionProcessor.Core.Entities;

namespace StrategyBank.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly TransactionDbContext _context;

    public TransactionRepository(TransactionDbContext context)
    {
        _context = context;
    }

    public void Add(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public Transaction GetById(Guid id)
    {
        return _context.Transactions.FirstOrDefault(t => t.Id == id);
    }
}
