using AutoMapper;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Profiles
{
    public class IncomeProfile : Profile
    {
        public IncomeProfile()
        {
            CreateMap<Income, IncomeDto>().ReverseMap();
        }
    }
}
