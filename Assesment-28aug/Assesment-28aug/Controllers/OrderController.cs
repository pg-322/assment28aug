using Assesment_28aug.Models;
using Assesment_28aug.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Assesment_28aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private OrderRepository _repo;

        public OrderController(OrderRepository repo)
        {
            _repo = repo;
        }


       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_repo.GetAllOrder(id)==null)
            {
                return NotFound();

            }
            else
            {
                return Ok(_repo.GetAllOrder(id));
            }
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            Order temp = _repo.PlaceOrder(order);
            return Ok(temp);

        }

       
       
    }
}
