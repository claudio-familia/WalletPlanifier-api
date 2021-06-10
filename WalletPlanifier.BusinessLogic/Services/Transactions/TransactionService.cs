using AutoMapper;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Services.Transactions
{
    public class TransactionService : BaseService<Transaction, TransactionDto>, ITransactionService
    {
        public TransactionService(IDataRepository<Transaction> dataRepository,
                                  IMapper mapper) : base(dataRepository, mapper)
        {
        }
    }
}
