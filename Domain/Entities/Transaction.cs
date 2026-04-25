using FinTrack.Domain.Enum;
using System.Security.Principal;

namespace FinTrack.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public DateTime DateUtc { get; private set; }
        public TransactionType Type { get; private set; }

        public int AccountId { get; set; }
        public Wallet Wallet { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        private Transaction() { }

        public static Transaction Create(
            decimal amount,
            string description,
            DateTime dateUtc,
            TransactionType type,
            int accountId,
            int categoryId,
            string userId)
        {
            if (amount <= 0) throw new ArgumentException("Сумма должна быть больше нуля.", nameof(amount));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Описание обязательно.", nameof(description));
            if (dateUtc > DateTime.UtcNow.AddDays(1)) throw new ArgumentException("Дата не может быть из будущего.", nameof(dateUtc));

            return new Transaction
            {
                Amount = amount,
                Description = description.Trim(),
                DateUtc = dateUtc,
                Type = type,
                AccountId = accountId,
                CategoryId = categoryId,
                UserId = userId
            };
        }

        public void Update(decimal amount, string description, int categoryId)
        {
            if (amount <= 0) throw new ArgumentException("Сумма должна быть больше нуля.", nameof(amount));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Описание обязательно.", nameof(description));

            Amount = amount;
            Description = description.Trim();
            CategoryId = categoryId;
            MarkAsUpdated();
        }
    }
}
