namespace WalletPlanifier.BusinessLogic.Dto
{
    public class WalletDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public UserDto User { get; set; }
    }
}
