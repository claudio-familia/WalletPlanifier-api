using System;
using System.Collections.Generic;
using System.Text;

namespace WalletPlanifier.Domain.Users
{
    public class WishList : BaseEntity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal AmountNeeded { get; set; }
        public bool IsGranted { get; set; }
    }
}
