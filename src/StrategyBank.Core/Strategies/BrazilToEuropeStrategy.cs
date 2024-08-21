using StrategyBank.Core.Enums;
using StrategyBank.Core.Strategies.Interfaces;
using TransactionProcessor.Core.Entities;

namespace StrategyBank.Core.Strategies;

public class BrazilToEuropeStrategy : ITransactionStrategy
{
    public bool IsApplicable(Transaction transaction) =>
        transaction.SourceCountry == Country.Brazil &&
        transaction.DestinationCountry != Country.Portugal &&
        ((int)transaction.DestinationCountry >= 30 && (int)transaction.DestinationCountry <= 39); // Exclui PT

    public void ApplyFee(Transaction transaction) =>
        transaction.Fee = 0.7m;
}
