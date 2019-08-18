using IGTI.PA.UseCases;
using IGTI.PA.UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGTI.PA.Init.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly Address _address;

        public AddressController(Address address)
        {
            _address = address;
        }

        [HttpPut("{uid}")]
        public IActionResult Put(string uid, [FromBody] AddressModel model)
        {
            model.Uid = uid;
            _address.Update(model);
            return Ok(model);
        }
    }
}
