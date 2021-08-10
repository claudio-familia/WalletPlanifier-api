using System;
using System.Collections.Generic;
using System.Text;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.BusinessLogic.Services.Contracts
{
    public interface IDebtService : IBaseService<Debt, DebtDto>
    {
        public TransactionDto AddTransaction(int id);
    }
}
