using AutoMapper;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Profiles
{
    public class FrecuencyProfile : Profile
    {
        public FrecuencyProfile()
        {
            CreateMap<Frecuency, FrecuencyDto>().ReverseMap();
        }
    }
}
