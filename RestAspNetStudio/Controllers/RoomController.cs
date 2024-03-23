using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNetStudio.Model;
using RestAspNetStudio.Logic;

namespace RestAspNetStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:ApiVersion}")]
    public class  RoomController : ControllerBase
    {
        
        private readonly ILogger<RoomController> _logger;
        private IRoomLogic _roomLogic;
        public RoomController(ILogger<RoomController> logger, IRoomLogic roomLogic)
        {
            _logger = logger;
            _roomLogic = roomLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_roomLogic.FindAll());    
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var room = _roomLogic.FindById(id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RoomVO room)
        {
            return Ok(_roomLogic.Create(room));
        }
        [HttpPut]
        public IActionResult Put([FromBody] RoomVO room)
        {
            if (room == null) return BadRequest();
            return Ok(_roomLogic.Update(room));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var room = _roomLogic.FindById(id);
            if(room == null)return NotFound();
            _roomLogic.Delete(id);
            return NoContent();
        }

    }
}
