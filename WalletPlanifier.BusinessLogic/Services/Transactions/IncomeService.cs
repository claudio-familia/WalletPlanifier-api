using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Transactions;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Services.Transactions
{
    public class IncomeService : BaseService<Income, IncomeDto>, IBaseService<Income, IncomeDto>
     {
        private readonly IDataRepository<Income> dataRepository;
        private readonly IDataRepository<User> userRepository;
        private readonly IDataRepository<Wallet> walletRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDataRepository<Domain.Transactions.Transaction> transactionRepository;
        private readonly IMapper mapper;

        public IncomeService(IDataRepository<Income> dataRepository,
                                  IDataRepository<User> userRepository,
                                  IDataRepository<Wallet> walletRepository,
                                  IUnitOfWork unitOfWork,
                                  IDataRepository<Domain.Transactions.Transaction> transactionRepository,
                                  IMapper mapper) : base(dataRepository, mapper)
        {
            this.dataRepository = dataRepository;
            this.userRepository = userRepository;
            this.walletRepository = walletRepository;
            this.unitOfWork = unitOfWork;
            this.transactionRepository = transactionRepository;
            this.mapper = mapper;
        }

        public override Income Add(IncomeDto newEntity)
        {
            var trans = unitOfWork.CreateTransaction();

            try
            {
                var income = base.Add(newEntity);

                var user = userRepository.Get(x => x, x => x.Id == income.UserId);
            
                var wallets = walletRepository.GetAll(x => x, x => x.UserId == income.UserId);

                transactionRepository.Add(new Domain.Transactions.Transaction()
                {
                    Income = income,
                    IncomeId = income.Id,
                    IsCompleted= false,
                    CompletedTime = DateTime.Now,
                    UserId = income.UserId,
                    WalletId = wallets.FirstOrDefault().Id
                });

                trans.Commit();

                return income;

            }
            catch (Exception ex)
            {
                trans.Rollback();

                throw new Exception(ex.Message);
            }
        }
    }
}
