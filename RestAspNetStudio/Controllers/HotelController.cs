using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNetStudio.Model;
using RestAspNetStudio.Logic;

namespace RestAspNetStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:ApiVersion}")]
    public class  HotelController : ControllerBase
    {
        
        private readonly ILogger<HotelController> _logger;
        private IHotelLogic _hotelLogic;
        public HotelController(ILogger<HotelController> logger, IHotelLogic hotelLogic)
        {
            _logger = logger;
            _hotelLogic = hotelLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_hotelLogic.FindAll());    
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var hotel = _hotelLogic.FindById(id);
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }
        [HttpPost]
        public IActionResult Post([FromBody] HotelVO hotel)
        {
            return Ok(_hotelLogic.Create(hotel));
        }
        [HttpPut]
        public IActionResult Put([FromBody] HotelVO hotel)
        {
            if (hotel == null) return BadRequest();
            return Ok(_hotelLogic.Update(hotel));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _hotelLogic.Delete(id);
            return NoContent();
        }

    }
}
