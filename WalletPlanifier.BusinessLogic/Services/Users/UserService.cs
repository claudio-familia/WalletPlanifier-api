using AutoMapper;
using Microsoft.Extensions.Configuration;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Services.Users
{
    public class UserService : BaseService<User, UserDto>, IBaseService<User, UserDto>
    {
        private readonly ICryptographyService _crytographyService;
        private readonly IConfiguration _configuration;

        public UserService(IDataRepository<User> _repository,
                           ICryptographyService crytographyService,
                           IConfiguration configuration,
                           ICurrentUserService currentUser,
                           IMapper mapper) : base(_repository, mapper, currentUser)
        {
            this._crytographyService = crytographyService;
            this._configuration = configuration;
        }

        public override User Add(UserDto entity)
        {
            entity.Password = _crytographyService.Encrypt(entity.Password, _configuration["Authentication:SecretKey"]);

            return base.Add(entity);
        }
    }
}
