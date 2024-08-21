using StrategyBank.Core.Enums;
using StrategyBank.Core.Strategies.Interfaces;
using TransactionProcessor.Core.Entities;

namespace StrategyBank.Core.Strategies;

public class BrazilToAsiaStrategy : ITransactionStrategy
{
    public bool IsApplicable(Transaction transaction) =>
        transaction.SourceCountry == Country.Brazil &&
        transaction.DestinationCountry != Country.China &&
        ((int)transaction.DestinationCountry >= 60 && (int)transaction.DestinationCountry <= 69);

    public void ApplyFee(Transaction transaction) =>
        transaction.Fee = 0.9m;
}
