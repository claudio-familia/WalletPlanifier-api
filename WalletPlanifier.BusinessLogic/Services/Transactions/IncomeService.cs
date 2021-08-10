using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Transactions;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Services.Transactions
{
    public class IncomeService : BaseService<Income, IncomeDto>, IIncomeService
    {
        private readonly IDataRepository<Income> dataRepository;
        private readonly IDataRepository<User> userRepository;
        private readonly IDataRepository<Wallet> walletRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICurrentUserService currentUser;
        private readonly IDataRepository<Domain.Transactions.Transaction> transactionRepository;
        private readonly ITransactionService transactionService;
        private readonly IMapper mapper;

        public IncomeService(IDataRepository<Income> dataRepository,
                                  IDataRepository<User> userRepository,
                                  IDataRepository<Wallet> walletRepository,
                                  IUnitOfWork unitOfWork,
                                  ICurrentUserService currentUser,
                                  IDataRepository<Domain.Transactions.Transaction> transactionRepository,
                                  ITransactionService transactionService,
                                  IMapper mapper) : base(dataRepository, mapper)
        {
            this.dataRepository = dataRepository;
            this.userRepository = userRepository;
            this.walletRepository = walletRepository;
            this.unitOfWork = unitOfWork;
            this.currentUser = currentUser;
            this.transactionRepository = transactionRepository;
            this.transactionService = transactionService;
            this.mapper = mapper;
        }

        public TransactionDto AddTransaction(int id)
        {
            var trans = unitOfWork.CreateTransaction();

            try
            {
                var income = dataRepository.Get(id);

                var user = userRepository.Get(x => x, x => x.Id == income.UserId);
            
                var wallets = walletRepository.GetAll(x => x, x => x.UserId == income.UserId);

                var transaction = transactionRepository.Add(new Domain.Transactions.Transaction()
                {
                    Income = income,
                    IncomeId = income.Id,
                    IsCompleted= false,
                    CompletedTime = DateTime.Now,
                    UserId = income.UserId,
                    WalletId = wallets.FirstOrDefault().Id
                });

                var result = transactionService.ProcessTransaction(income.UserId, transaction.Id);

                trans.Commit();

                return result;

            }
            catch (Exception ex)
            {
                trans.Rollback();

                throw new Exception(ex.Message);
            }
        }

        public override IEnumerable<IncomeDto> GetAll()
        {
            var result = repository.GetAll(x => x.Include(i => i.Frecuency)).Where(x => x.CreatorUserId == currentUser.UserId);

            return mapper.Map<IEnumerable<IncomeDto>>(result);
        }

        public override IncomeDto Get(int id)
        {
            var result = dataRepository.Get(x => x.Include(i => i.Frecuency).Include(x => x.Transactions), x => x.Id == id);            

            if (result.CreatorUserId != currentUser.UserId) throw new TypeAccessException("This resource does not belong to the requester");

            //result.Transactions = transactionRepository.GetAll(x => x, i => i.IncomeId.Value == result.Id);

            return mapper.Map<IncomeDto>(result);
        }
    }
}
