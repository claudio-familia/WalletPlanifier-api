using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Services.Contracts
{
    public interface ITransactionService : IBaseService<Transaction, TransactionDto>
    {
    }
}
