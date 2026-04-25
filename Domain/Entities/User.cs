using Microsoft.AspNetCore.Identity;
using System.Transactions;
namespace FinTrack.Domain.Entities

{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
