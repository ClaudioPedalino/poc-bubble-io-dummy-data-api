using Microsoft.AspNetCore.Mvc;
using Products.api.Interfaces;
using Products.api.Models;
using System;

namespace Products.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public ActionResult Get(Guid productId)
        {
            return Ok(_service.GetById(productId));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductDto dto)
        {
            return Ok(_service.Create(dto));
        }

        //[HttpPatch]
        //public ActionResult Update([FromBody] ProductDto dto)
        //{
        //    return Ok(_service.Create(dto));
        //}

        [HttpDelete("{productId}")]
        public ActionResult Delete(Guid productId)
        {
            return Ok(_service.Delete(productId));
        }
    }
}