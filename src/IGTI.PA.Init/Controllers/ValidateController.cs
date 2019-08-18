using IGTI.PA.UseCases;
using IGTI.PA.UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGTI.PA.Init.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly Validate _validate;

        public ValidateController(Validate validate)
        {
            _validate = validate;
        }

        [HttpPost("{uid}")]
        public IActionResult Post(string uid, [FromBody] ValidateModel model)
        {
            model.Uid = uid;
            var step = _validate.Validate(model);

            if (step is null)
                return StatusCode(401);

            return Ok(step);
        }
    }
}