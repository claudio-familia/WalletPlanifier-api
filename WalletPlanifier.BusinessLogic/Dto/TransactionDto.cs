namespace WalletPlanifier.BusinessLogic.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public int IncomeId { get; set; }
        public int DebtId { get; set; }
        public int SavingId { get; set; }
    }
}
