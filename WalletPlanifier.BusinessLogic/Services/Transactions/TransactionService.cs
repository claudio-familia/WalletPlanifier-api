using AutoMapper;
using System.Collections.Generic;
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

        public IEnumerable<TransactionDto> GetAllByClient(int userId)
        {
            throw new System.NotImplementedException();
        }

        public TransactionDto GetTransactionById(int userId, int transactionId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TransactionDto> ProcessAllUserTransaction(int userId)
        {
            throw new System.NotImplementedException();
        }

        public TransactionDto ProcessTransaction(int userId, int transactionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
