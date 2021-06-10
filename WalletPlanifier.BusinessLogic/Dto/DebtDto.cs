using System;

namespace WalletPlanifier.BusinessLogic.Dto
{
    public class DebtDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FrecuencyId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsFixed { get; set; }
        public DateTime EndDate { get; set; }

        public UserDto User { get; set; }
        public FrecuencyDto Frecuency { get; set; }
    }
}
