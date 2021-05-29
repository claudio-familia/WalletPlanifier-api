using System;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.Domain.Transactions
{
    public class Debt : BaseEntity
    {
        public int UserId { get; set; }
        public int FrecuencyId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsFixed { get; set; }
        public DateTime EndDate { get; set; }

        public User User { get; set; }
        public Frecuency Frecuency { get; set; }
    }
}
