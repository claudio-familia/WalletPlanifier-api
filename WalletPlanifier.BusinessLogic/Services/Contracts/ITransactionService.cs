using System.Collections.Generic;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Services.Contracts
{
    public interface ITransactionService : IBaseService<Transaction, TransactionDto>
    {
        public TransactionDto ProcessTransaction(int userId, int transactionId);
        public Transaction ProcessSingleTransaction(int userId, int transactionId);
        public IEnumerable<TransactionDto> ProcessAllUserTransaction(int userId);
        public IEnumerable<TransactionDto> GetAllByClient(int userId);
        TransactionDto GetTransactionById(int userId, int transactionId);
    }
}
