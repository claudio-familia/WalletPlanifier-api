using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Controllers.Base;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : BaseController<Transaction, TransactionDto>
    {
        public TransactionsController(IBaseService<Transaction, TransactionDto> baseService) : base(baseService)
        {
        }
    }
}
