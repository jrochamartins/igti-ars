using IGTI.PA.UseCases;
using IGTI.PA.UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGTI.PA.Init.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly AccountType _useCase;

        public AccountTypeController(AccountType useCase)
        {
            _useCase = useCase;
        }

        [HttpPut("{uid}")]
        public IActionResult Put(string uid, [FromBody] AccountTypeModel model)
        {
            model.Uid = uid;
            _useCase.Update(model);
            return Ok(model);
        }
    }
}