namespace FinTrack.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = "RUB";
        public bool IsArchived { get; private set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void Archive() => IsArchived = true;
        public void Restore() => IsArchived = false;
    }
}
