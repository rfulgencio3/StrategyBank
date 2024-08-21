using StrategyBank.Core.Enums;
using StrategyBank.Core.Strategies.Interfaces;
using TransactionProcessor.Core.Entities;

namespace StrategyBank.Core.Strategies;

public class BrazilToEnglandStrategy : ITransactionStrategy
{
    public bool IsApplicable(Transaction transaction) =>
        transaction.SourceCountry == Country.Brazil && transaction.DestinationCountry == Country.England;

    public void ApplyFee(Transaction transaction) =>
        transaction.Fee = 0.4m;
}
