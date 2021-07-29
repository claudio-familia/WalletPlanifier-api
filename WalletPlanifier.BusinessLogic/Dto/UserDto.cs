using System;
using System.Collections.Generic;
using System.Text;

namespace WalletPlanifier.BusinessLogic.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Profession { get; set; }
    }
}
