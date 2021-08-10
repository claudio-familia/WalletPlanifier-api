using System.Collections.Generic;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.Domain.Transactions
{
    public class Wallet : BaseEntity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
