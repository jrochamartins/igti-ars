using IGTI.PA.UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGTI.PA.Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UseCases.Login _login;

        public LoginController(UseCases.Login login)
        {
            _login = login;
        }

        [HttpPut("{uid}")]
        public IActionResult Put(string uid, [FromBody] LoginModel model)
        {
            model.Uid = uid;
            _login.Enter(model);
            return Ok(model);
        }
    }
}
