using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNet8VStudio.Logic;
using RestAspNet8VStudio.VObject;
using RestAspNetStudio.Logic;

namespace RestAspNet8VStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationLogic _reservationLogic;

        public ReservationController(ILogger<ReservationController> logger, IReservationLogic reservationLogic)
        {
            _logger = logger;
            _reservationLogic = reservationLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_reservationLogic.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var reservation = _reservationLogic.FindById(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservationVO reservation)
        {
            return Ok(_reservationLogic.Create(reservation));
        }

        [HttpPut("{id?}")]
        public IActionResult Put([FromBody] ReservationVO reservation, long? id)
        {
            if (reservation == null || id != null) return BadRequest();
            ReservationVO result = _reservationLogic.Update(reservation);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var reservation = _reservationLogic.FindById(id);
            if (reservation == null) return NotFound();
            _reservationLogic.Delete(id);
            return NoContent();
        }

    }
}
