using Microsoft.AspNetCore.Mvc;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Models;

namespace WalletPlanifier.Controllers.Base
{
    public class BaseController<T, Dto> : ControllerBase
        where T : class, IAuditableEntity, new()
        where Dto : class, new()
    {
        private readonly IBaseService<T, Dto> _baseService;
        public BaseController(IBaseService<T, Dto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_baseService.GetAll());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var response = _baseService.Get(id);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public virtual IActionResult Post(T entity)
        {
            var response = _baseService.Add(entity);

            return Ok(response);
        }

        [HttpPut]
        public virtual IActionResult Put(T entity)
        {
            var response = _baseService.Update(entity);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual IActionResult Delete(int id)
        {
            var entity = _baseService.GetEntity(id);

            entity.IsDeleted = true;

            var response = _baseService.Update(entity);

            return Ok(response);
        }
    }
}
