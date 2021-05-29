using System;
using System.Collections.Generic;
using System.Text;

namespace WalletPlanifier.Domain.Transactions
{
    public class Transaction : BaseEntity
    {
        public int WalletId { get; set; }
        public int IncomeId { get; set; }
        public int DebtId { get; set; }
        public int SavingId { get; set; }
    }
}
