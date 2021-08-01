using AutoMapper;
using System;
using System.Linq;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Transactions;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Services.Transactions
{
    public class DebtService : BaseService<Debt, DebtDto>, IBaseService<Debt, DebtDto>
    {
        private readonly IDataRepository<Debt> dataRepository;
        private readonly IDataRepository<User> userRepository;
        private readonly IDataRepository<Wallet> walletRepository;
        private readonly IDataRepository<Domain.Transactions.Transaction> transactionRepository;
        private readonly IMapper mapper;

        public DebtService(IDataRepository<Debt> dataRepository,
                           IDataRepository<User> userRepository,
                           IDataRepository<Wallet> walletRepository,
                           IDataRepository<Domain.Transactions.Transaction> transactionRepository,
                           IMapper mapper) : base(dataRepository, mapper)
        {
            this.dataRepository = dataRepository;
            this.userRepository = userRepository;
            this.walletRepository = walletRepository;
            this.transactionRepository = transactionRepository;
            this.mapper = mapper;
        }

        public override Debt Add(DebtDto newEntity)
        {
            var debt = base.Add(newEntity);

            var user = userRepository.Get(x => x, x => x.Id == debt.UserId);

            var wallets = walletRepository.GetAll(x => x, x => x.UserId == debt.UserId);

            transactionRepository.Add(new Domain.Transactions.Transaction()
            {
                Debt = debt,
                DebtId = debt.Id,
                IsCompleted = false,
                CompletedTime = DateTime.Now,
                UserId = debt.UserId,
                WalletId = wallets.FirstOrDefault().Id
            });

            return debt;
        }
    }
}

