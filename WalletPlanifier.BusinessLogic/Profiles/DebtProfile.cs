using AutoMapper;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Profiles
{
    public class DebtProfile : Profile
    {
        public DebtProfile()
        {
            CreateMap<Debt, DebtDto>().ReverseMap();
        }
    }
}
