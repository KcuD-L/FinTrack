using FinTrack.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System.Transactions;
namespace FinTrack.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public TransactionType Type { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Category() { }

        public Category(string name, TransactionType type, string userId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название категории не может быть пустым.", nameof(name));

            Name = name.Trim();
            Type = type;
            UserId = userId;
        }
    }
}
