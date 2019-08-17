using IGTI.PA.UseCases;
using IGTI.PA.UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGTI.PA.Init.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly Register _register;

        public RegisterController(Register register)
        {
            _register = register;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegisterModel model)
        {
            var created = _register.Create(model);

            if (created)
                return CreatedAtAction("Post", model);

            return Ok();
        }
    }
}
