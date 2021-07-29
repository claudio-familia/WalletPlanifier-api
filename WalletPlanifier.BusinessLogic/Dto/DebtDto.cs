using System;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public UserDto User { get; set; }
        [JsonIgnore]
        public FrecuencyDto Frecuency { get; set; }
    }
}
