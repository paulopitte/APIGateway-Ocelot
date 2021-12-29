using Microsoft.AspNetCore.Mvc;

namespace Mkt.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var ordens = new string[]
            {
                "Order: 12345 - Total Items 2 - Price: 100.23",
                "Order: 1x628dd - Total Items 28 - Price: 13933.99",
                "Order: 59877ML - Total Items 7 - Price: 999.87",
                "Order: ML-266 - Total Items 5 - Price 3009.99",
                 
            };

            return Ok(ordens);
        }
    }
}
