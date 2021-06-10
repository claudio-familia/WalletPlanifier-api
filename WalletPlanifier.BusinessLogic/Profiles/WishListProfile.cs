using AutoMapper;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Profiles
{
    public class WishListProfile : Profile
    {
        public WishListProfile()
        {
            CreateMap<WishList, WishListDto>().ReverseMap();
        }
    }
}
