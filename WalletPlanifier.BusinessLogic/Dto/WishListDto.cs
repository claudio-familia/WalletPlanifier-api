namespace WalletPlanifier.BusinessLogic.Dto
{
    public class WishListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal AmountNeeded { get; set; }
        public bool IsGranted { get; set; }
    }
}
