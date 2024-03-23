using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNet8VStudio.Logic;
using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PriceController : ControllerBase
    {
        private readonly ILogger<PriceController> _logger;
        private readonly IPriceLogic _priceLogic;

        public PriceController(ILogger<PriceController> logger, IPriceLogic priceLogic)
        {
            _logger = logger;
            _priceLogic = priceLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_priceLogic.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var price = _priceLogic.FindById(id);
            if (price == null) return NotFound();
            return Ok(price);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PriceVO price)
        {
            return Ok(_priceLogic.Create(price));
        }

        [HttpPut("{id?}")]
        public IActionResult Put([FromBody] PriceVO price, long? id)
        {
            if (price == null || id != null) return BadRequest();
            PriceVO result = _priceLogic.Update(price);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var price = _priceLogic.FindById(id);
            if (price == null) return NotFound();
           _priceLogic.Delete(id);
            return NoContent();
        }

    }
}
