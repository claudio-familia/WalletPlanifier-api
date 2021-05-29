namespace WalletPlanifier.Domain.Transactions
{
    public class Frecuency : BaseEntity
    {
        public string Description { get; set; }
        public int AmountInDays { get; set; }
    }
}
