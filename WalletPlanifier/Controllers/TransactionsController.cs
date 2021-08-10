using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Services.Contracts;

namespace WalletPlanifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _baseService;
        private readonly ICurrentUserService currentUserService;

        public TransactionsController(ITransactionService baseService, ICurrentUserService currentUserService)
        {
            this._baseService = baseService;
            this.currentUserService = currentUserService;
        }

        [HttpGet()]
        public IActionResult GetAllByClient()
        {            
            return Ok(_baseService.GetAllByClient(currentUserService.UserId.Value));
        }

        [HttpGet("{userId}")]
        public IActionResult GetAllByClient(int userId)
        {
            return Ok(_baseService.GetAllByClient(userId));
        }

        [HttpGet("{userId}/{transactionId}")]
        public IActionResult Get(int userId, int transactionId)
        {
            var response = _baseService.GetTransactionById(userId, transactionId);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPost("{userId}/{transactionId}")]
        public IActionResult ProcessTransaction(int userId, int transactionId)
        {
            return Ok(_baseService.ProcessTransaction(userId, transactionId));
        }

        [HttpPost("{userId}")]
        public IActionResult ProcessAllUserTransaction(int userId)
        {
            return Ok(_baseService.ProcessAllUserTransaction(userId));
        }
    }
}
