using AutoMapper;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}
