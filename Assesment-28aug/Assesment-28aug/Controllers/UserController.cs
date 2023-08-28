using Assesment_28aug.Models;
using Assesment_28aug.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_28aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _userrepo;
        public UserController(UserRepository repo)

        {
            _userrepo = repo;
        }
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var obj = _userrepo.Login(user);
            if (obj == null)
            {
                return Unauthorized();
            }
            return Ok(new { token = obj });
        }



        [HttpPost("posts")]
        public IActionResult Register([FromBody] User user)
        {
            var obj = _userrepo.Register(user);
            return CreatedAtAction("User Created", user);
        }
    }
}
