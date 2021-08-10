using System;
using System.Collections.Generic;
using System.Text;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Services.Contracts
{
    public interface IIncomeService : IBaseService<Income, IncomeDto>
    {
        public TransactionDto AddTransaction(int id);
    }
}
