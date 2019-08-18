using IGTI.PA.UseCases;
using IGTI.PA.UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGTI.PA.Init.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        private readonly Financial _useCase;

        public FinancialController(Financial useCase)
        {
            _useCase = useCase;
        }

        [HttpPut("{uid}")]
        public IActionResult Put(string uid, [FromBody] FinancialModel model)
        {
            model.Uid = uid;
            _useCase.Update(model);
            return Ok(model);
        }
    }
}