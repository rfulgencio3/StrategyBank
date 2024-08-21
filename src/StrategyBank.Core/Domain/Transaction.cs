using StrategyBank.Core.Domain;
using StrategyBank.Core.Enums;

namespace TransactionProcessor.Core.Entities;

public class Transaction : Base
{
    public Country SourceCountry { get; set; }
    public Country DestinationCountry { get; set; }
    public decimal Amount { get; set; }
    public decimal Fee { get; set; }
    public string AppliedRule { get; set; }
}