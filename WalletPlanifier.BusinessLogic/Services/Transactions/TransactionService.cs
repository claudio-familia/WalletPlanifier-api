using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Services.Transactions
{
    public class TransactionService : BaseService<Transaction, TransactionDto>, ITransactionService
    {
        private readonly IDataRepository<Transaction> dataRepository;
        private readonly IDataRepository<Wallet> walletRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TransactionService(IDataRepository<Transaction> dataRepository,
                                  IDataRepository<Wallet> walletRepository,
                                  IUnitOfWork unitOfWork,
                                  ICurrentUserService currentUser,
                                  IMapper mapper) : base(dataRepository, mapper)
        {
            this.dataRepository = dataRepository;
            this.walletRepository = walletRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<TransactionDto> GetAllByClient(int userId)
        {
            return mapper.Map<IEnumerable<TransactionDto>>(dataRepository.GetAll(x => x.Include(i => i.User)
                                                                                       .Include(i => i.Wallet)
                                                                                       .Include(i => i.Debt)
                                                                                       .Include(i => i.Income), 
                                                                                x => x.UserId == userId));
        }

        public TransactionDto GetTransactionById(int userId, int transactionId)
        {
            return mapper.Map<TransactionDto>(dataRepository.Get(x => x.Include(i => i.User)
                                                                       .Include(i => i.Wallet)
                                                                       .Include(i => i.Debt)
                                                                       .Include(i => i.Income), 
                                                                 x => x.UserId == userId && x.Id == transactionId));
        }

        public IEnumerable<TransactionDto> ProcessAllUserTransaction(int userId)
        {
            var trans = unitOfWork.CreateTransaction();

            try
            {
                var transactions = dataRepository.GetAll(x => x.Include(x => x.Income).Include(x => x.Debt), x => x.UserId == userId);

                foreach(var transaction in transactions)
                {

                    var wallet = walletRepository.Get(w => w, w => w.Id == transaction.WalletId);

                    transaction.OriginWalletValue = wallet.Total;

                    if (transaction.DebtId.HasValue)
                    {
                        transaction.Description = "Debt's transaction";
                        transaction.Title = transaction.Debt.Description;
                        wallet.Total -= transaction.Debt.Amount;
                    }

                    if (transaction.IncomeId.HasValue)
                    {
                        transaction.Description = "Income's transaction";
                        transaction.Title = transaction.Income.Description;
                        wallet.Total += transaction.Income.Amount;
                    }

                    transaction.FinalWalletValue = wallet.Total;
                    transaction.IsCompleted = true;
                    transaction.CompletedTime = DateTime.Now;

                    walletRepository.Update(wallet);
                    dataRepository.Update(transaction);
                }

                trans.Commit();

                return mapper.Map<IEnumerable<TransactionDto>>(transactions);
            }
            catch(Exception ex)
            {
                trans.Rollback();

                throw new Exception(ex.Message);
            }
        }

        public TransactionDto ProcessTransaction(int userId, int transactionId)
        {
            var trans = unitOfWork.CreateTransaction();

            try
            {
                Transaction transaction = ProcessSingleTransaction(userId, transactionId);

                trans.Commit();

                return mapper.Map<TransactionDto>(transaction);
            }
            catch (Exception ex)
            {
                trans.Rollback();

                throw new Exception(ex.Message);
            }

        }

        public Transaction ProcessSingleTransaction(int userId, int transactionId)
        {
            var transaction = dataRepository.Get(x => x, x => x.UserId == userId && x.Id == transactionId);

            var wallet = walletRepository.Get(w => w, w => w.Id == transaction.WalletId);

            transaction.OriginWalletValue = wallet.Total;

            if (transaction.DebtId.HasValue)
            {
                transaction.Description = "Debt's transaction";
                wallet.Total -= transaction.Debt.Amount;
            }

            if (transaction.IncomeId.HasValue)
            {
                transaction.Description = "Income's transaction";
                wallet.Total += transaction.Income.Amount;
            }

            transaction.FinalWalletValue = wallet.Total;
            transaction.IsCompleted = true;
            transaction.CompletedTime = DateTime.Now;

            walletRepository.Update(wallet);
            dataRepository.Update(transaction);
            return transaction;
        }
    }    
}
