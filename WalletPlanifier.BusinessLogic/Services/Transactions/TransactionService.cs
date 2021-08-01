using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Services.Transactions
{
    public class TransactionService : BaseService<Transaction, TransactionDto>, ITransactionService
    {
        private readonly IDataRepository<Transaction> dataRepository;
        private readonly IDataRepository<Wallet> walletRepository;
        private readonly IMapper mapper;

        public TransactionService(IDataRepository<Transaction> dataRepository,
                                  IDataRepository<Wallet> walletRepository,
                                  IMapper mapper) : base(dataRepository, mapper)
        {
            this.dataRepository = dataRepository;
            this.walletRepository = walletRepository;
            this.mapper = mapper;
        }

        public IEnumerable<TransactionDto> GetAllByClient(int userId)
        {
            return mapper.Map<IEnumerable<TransactionDto>>(dataRepository.GetAll(x => x, x => x.UserId == userId));
        }

        public TransactionDto GetTransactionById(int userId, int transactionId)
        {
            return mapper.Map<TransactionDto>(dataRepository.Get(x => x, x => x.UserId == userId && x.Id == transactionId));
        }

        public IEnumerable<TransactionDto> ProcessAllUserTransaction(int userId)
        {
            var transactions = dataRepository.GetAll(x => x.Include(x => x.Income).Include(x => x.Debt), x => x.UserId == userId);

            foreach(var transaction in transactions)
            {

                var wallet = walletRepository.Get(w => w, w => w.Id == transaction.WalletId);

                if (transaction.DebtId.HasValue)
                {
                    wallet.Total -= transaction.Debt.Amount;
                }

                if (transaction.IncomeId.HasValue)
                {
                    wallet.Total += transaction.Income.Amount;
                }

                transaction.IsCompleted = true;
                transaction.CompletedTime = DateTime.Now;

                walletRepository.Update(wallet);
                dataRepository.Update(transaction);
            }

            return mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public TransactionDto ProcessTransaction(int userId, int transactionId)
        {
            var transaction = dataRepository.Get(x => x, x => x.UserId == userId && x.Id == transactionId);

            var wallet = walletRepository.Get(w => w, w => w.Id == transaction.WalletId);

            if (transaction.DebtId.HasValue)
            {
                wallet.Total -= transaction.Debt.Amount;
            }

            if (transaction.IncomeId.HasValue)
            {
                wallet.Total += transaction.Income.Amount;
            }

            transaction.IsCompleted = true;
            transaction.CompletedTime = DateTime.Now;

            walletRepository.Update(wallet);
            dataRepository.Update(transaction);

            return mapper.Map<TransactionDto>(transaction);
        }
    }    
}
