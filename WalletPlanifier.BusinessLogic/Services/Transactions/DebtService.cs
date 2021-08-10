using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Transactions;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Services.Transactions
{
    public class DebtService : BaseService<Debt, DebtDto>, IDebtService
    {
        private readonly IDataRepository<Debt> dataRepository;
        private readonly IDataRepository<User> userRepository;
        private readonly IDataRepository<Wallet> walletRepository;
        private readonly ICurrentUserService currentUser;
        private readonly IDataRepository<Domain.Transactions.Transaction> transactionRepository;
        private readonly ITransactionService transactionService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DebtService(IDataRepository<Debt> dataRepository,
                           IDataRepository<User> userRepository,
                           IDataRepository<Wallet> walletRepository,
                           ICurrentUserService currentUser,
                           IDataRepository<Domain.Transactions.Transaction> transactionRepository,
                           ITransactionService transactionService,
                           IUnitOfWork unitOfWork,
                           IMapper mapper) : base(dataRepository, mapper)
        {
            this.dataRepository = dataRepository;
            this.userRepository = userRepository;
            this.walletRepository = walletRepository;
            this.currentUser = currentUser;
            this.transactionRepository = transactionRepository;
            this.transactionService = transactionService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public TransactionDto AddTransaction(int id)
        {
            var trans = unitOfWork.CreateTransaction();

            try
            {                
                var debt = dataRepository.Get(id);

                var user = userRepository.Get(x => x, x => x.Id == debt.UserId);

                var wallets = walletRepository.GetAll(x => x, x => x.UserId == debt.UserId);

                var transaction = transactionRepository.Add(new Domain.Transactions.Transaction()
                {
                    Debt = debt,
                    DebtId = debt.Id,
                    IsCompleted = false,
                    Title = debt.Description,
                    CompletedTime = DateTime.Now,
                    UserId = debt.UserId,
                    WalletId = wallets.FirstOrDefault().Id
                });

                var result = transactionService.ProcessSingleTransaction(debt.UserId, transaction.Id);

                trans.Commit();

                return mapper.Map<TransactionDto>(result);
            }
            catch(Exception ex)
            {
                trans.Rollback();

                throw new Exception(ex.Message);
            }

        }

        public override IEnumerable<DebtDto> GetAll()
        {
            var result = repository.GetAll(x => x.Include(i => i.Frecuency)).Where(x => x.CreatorUserId == currentUser.UserId);

            return mapper.Map<IEnumerable<DebtDto>>(result);
        }

        public override DebtDto Get(int id)
        {
            var result = dataRepository.Get(x => x.Include(i => i.Frecuency).Include(x => x.Transactions), x => x.Id == id);

            if (result.CreatorUserId != currentUser.UserId) throw new TypeAccessException("This resource does not belong to the requester");

            return mapper.Map<DebtDto>(result);
        }
    }
}

