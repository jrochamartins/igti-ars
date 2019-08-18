using IGTI.PA.UseCases;
using IGTI.PA.UseCases.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IGTI.PA.Init.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly Review _useCase;

        public ReviewController(Review useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{uid}")]
        public IActionResult Get(string uid)
        {
            try
            {
                var review = _useCase.Get(uid);

                if (review is null)
                    return NotFound();

                return Ok(review);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{uid}")]
        public IActionResult Put(string uid, [FromBody] ReviewAcceptModel model)
        {
            try
            {
                model.Uid = uid;
                _useCase.Accept(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}