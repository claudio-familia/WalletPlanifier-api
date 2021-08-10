using System;

namespace WalletPlanifier.BusinessLogic.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WalletId { get; set; }
        public int? IncomeId { get; set; }
        public int? DebtId { get; set; }
        public decimal? OriginWalletValue { get; set; }
        public decimal? FinalWalletValue { get; set; }
        public string Description { get; set; }        
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedTime { get; set; }

        public IncomeDto Income { get; set; }
        public DebtDto Debt { get; set; }
        public WalletDto Wallet { get; set; }
        public UserDto User { get; set; }
    }
}
