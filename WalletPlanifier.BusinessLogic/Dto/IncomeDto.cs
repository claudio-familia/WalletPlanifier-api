using System;
using System.Collections.Generic;
using System.Text;

namespace WalletPlanifier.BusinessLogic.Dto
{
    public class IncomeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FrecuencyId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public UserDto User { get; set; }
        public FrecuencyDto Frecuency { get; set; }
    }
}
