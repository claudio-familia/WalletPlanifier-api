using System;
using System.Collections.Generic;
using System.Text;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.Domain.Transactions
{
    public class Transaction : BaseEntity
    {
        public int UserId { get; set; }
        public int WalletId { get; set; }
        public int? IncomeId { get; set; }
        public int? DebtId { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedTime { get; set; }

        public Income Income { get; set; }
        public Debt Debt { get; set; }
        public Wallet Wallet { get; set; }
        public User User { get; set; }
    }
}
