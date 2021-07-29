using System.Text.Json.Serialization;

namespace WalletPlanifier.BusinessLogic.Dto
{
    public class WalletDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        [JsonIgnore]
        public UserDto User { get; set; }
    }
}
