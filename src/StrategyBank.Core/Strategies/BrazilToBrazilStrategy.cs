using StrategyBank.Core.Enums;
using StrategyBank.Core.Strategies.Interfaces;
using TransactionProcessor.Core.Entities;

namespace StrategyBank.Core.Strategies;

public class BrazilToBrazilStrategy : ITransactionStrategy
{
    public bool IsApplicable(Transaction transaction) =>
        transaction.SourceCountry == Country.Brazil && transaction.DestinationCountry == Country.Brazil;

    public void ApplyFee(Transaction transaction) =>
        transaction.Fee = 0.1m;
}