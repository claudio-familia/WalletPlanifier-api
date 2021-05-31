using AutoMapper;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
