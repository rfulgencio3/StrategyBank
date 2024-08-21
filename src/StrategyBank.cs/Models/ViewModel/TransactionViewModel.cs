namespace StrategyBank.Application.Models.ViewModel;

public class TransactionViewModel
{
    public Guid Id { get; set; }
    public string AppliedRule { get; set; }
    public decimal Fee { get; set; }
    public DateTime CreateDate { get; set; }
}
