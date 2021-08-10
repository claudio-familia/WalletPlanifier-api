using System.Collections.Generic;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.Domain.Transactions
{
    public class Income : BaseEntity
    {
        public int UserId { get; set; }
        public int FrecuencyId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public User User { get; set; }
        public Frecuency Frecuency { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
