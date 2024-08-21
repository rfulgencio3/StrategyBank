namespace StrategyBank.Application.Models.InputModel;

public class TransactionInputModel
{
    public int SourceCountry { get; set; }
    public int DestinationCountry { get; set; }
    public decimal Amount { get; set; }
}
