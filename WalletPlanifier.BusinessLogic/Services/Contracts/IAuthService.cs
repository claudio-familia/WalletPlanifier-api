using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Services.Contracts
{
    public interface IAuthService
    {
        public User Login(string username, string password);
        string GenerateJWT(User user);
    }
}
