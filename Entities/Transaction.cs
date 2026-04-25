using FinTrack.Enum;

namespace FinTrack.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public TransactionType Type { get; set; }


        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
