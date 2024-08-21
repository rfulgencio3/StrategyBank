using StrategyBank.Application.Models.InputModel;
using StrategyBank.Application.Models.ViewModel;
using StrategyBank.Core.Enums;
using StrategyBank.Core.Repositories;
using StrategyBank.Core.Strategies;
using StrategyBank.Core.Strategies.Interfaces;
using TransactionProcessor.Core.Entities;

namespace StrategyBank.Application.Services;

public class TransactionService
{
    private readonly IEnumerable<ITransactionStrategy> _strategies;
    private readonly ITransactionRepository _repository;

    public TransactionService(IEnumerable<ITransactionStrategy> strategies, ITransactionRepository repository)
    {
        _strategies = strategies;
        _repository = repository;
    }

    public TransactionViewModel ProcessTransaction(TransactionInputModel inputModel)
    {
        var transaction = new Transaction
        {
            SourceCountry = (Country)inputModel.SourceCountry,
            DestinationCountry = (Country)inputModel.DestinationCountry,
            Amount = inputModel.Amount
        };

        foreach (var strategy in _strategies)
        {
            Console.WriteLine($"Checking strategy: {strategy.GetType().Name}");

            if (strategy.IsApplicable(transaction))
            {
                Console.WriteLine($"Applying strategy: {strategy.GetType().Name}");
                strategy.ApplyFee(transaction);
                transaction.AppliedRule = strategy.GetType().Name;
                break;
            }
        }

        if (string.IsNullOrEmpty(transaction.AppliedRule))
        {
            var defaultStrategy = new DefaultStrategy();
            defaultStrategy.ApplyFee(transaction);
            transaction.AppliedRule = defaultStrategy.GetType().Name;
        }

        _repository.Add(transaction);

        return new TransactionViewModel
        {
            Id = transaction.Id,
            AppliedRule = transaction.AppliedRule,
            Fee = transaction.Fee,
            CreateDate = transaction.CreateDate
        };
    }
}
