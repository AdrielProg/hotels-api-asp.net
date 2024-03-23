using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAspNetStudio.Model;
using RestAspNetStudio.Logic;

namespace RestAspNetStudio.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:ApiVersion}")]
    public class  UserController : ControllerBase
    {
        
        private readonly ILogger<UserController> _logger;
        private IUserLogic _userLogic;
        public UserController(ILogger<UserController> logger, IUserLogic userLogic)
        {
            _logger = logger;
            _userLogic = userLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userLogic.FindAll());    
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _userLogic.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);

        }

        [HttpPost]
        public IActionResult Post([FromBody] UserVO user)
        {

            return Ok(_userLogic.Create(user));

        }
        [HttpPut]
        public IActionResult Put([FromBody] UserVO user)
        {
            if (user == null) return BadRequest();
            return Ok(_userLogic.Update(user));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _userLogic.FindById(id);
            if (user == null) return NotFound();
            _userLogic.Delete(id);
            return NoContent();
        }

    }
}
