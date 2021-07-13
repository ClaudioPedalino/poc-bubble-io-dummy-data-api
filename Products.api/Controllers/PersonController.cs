using Microsoft.AspNetCore.Mvc;
using Products.api.Interfaces;
using Products.api.Models;
using Products.api.Models.Queries;
using System;

namespace Products.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<DataResult<PersonDto>> GetAll([FromQuery] GetPersonQuery request)
        {
            return Ok(_service.GetAll(request));
        }

        [HttpGet("{personId}")]
        public ActionResult<PersonDto> Get(Guid personId)
        {
            return Ok(_service.GetById(personId));
        }

        [HttpPost]
        public ActionResult<Result> CreatePerson([FromBody] PersonDto request)
        {
            var result = _service.Create(request);

            return result.HasErrors
                ? BadRequest(result)
                : (ActionResult<Result>)Ok(result);
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        [HttpDelete("{productId}")]
        public ActionResult<Result> DeletePerson(Guid productId)
        {
            var result = _service.Delete(productId);

            return result.HasErrors
                ? BadRequest(result)
                : (ActionResult<Result>)Ok(result);
        }
    }
}