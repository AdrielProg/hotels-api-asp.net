using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNetStudio.Model;
using RestAspNetStudio.Logic;
using RestAspNetStudio.Logic.Implementations;

namespace RestAspNetStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:ApiVersion}")]
    public class  HotelController : ControllerBase
    {
        
        private readonly ILogger<HotelController> _logger;
        private IHotelLogic _hotelLogic;
        private IRoomLogic _roomLogic;
        public HotelController(ILogger<HotelController> logger, IHotelLogic hotelLogic, IRoomLogic roomLogic)
        {
            _logger = logger;
            _hotelLogic = hotelLogic;
            _roomLogic = roomLogic;
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
        [HttpGet("{id}/rooms")]
        public IActionResult GetHotelRooms(long id)
        {
            var hotel = _hotelLogic.FindById(id);
            if (hotel == null)
            {
                _logger.LogInformation($"Hotel com ID {id} n�o encontrado.");
                return NotFound("Hotel n�o encontrado.");
            }

            var rooms = _roomLogic.FindRoomsByHotelId(id);
            if (rooms == null || rooms.Count == 0)
            {
                _logger.LogInformation($"Quartos para o hotel com ID {id} n�o encontrados.");
                return NotFound("Quartos para este hotel n�o encontrados.");
            }

            return Ok(rooms);
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
