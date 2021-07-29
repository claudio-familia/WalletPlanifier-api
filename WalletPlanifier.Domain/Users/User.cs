using System;
using System.Collections.Generic;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.Domain.Users
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Profession { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
    }
}
