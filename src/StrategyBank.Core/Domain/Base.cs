namespace StrategyBank.Core.Domain
{
    public abstract class Base
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreateDate { get; private set; } = DateTime.UtcNow;
    }
}
