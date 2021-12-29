using Microsoft.AspNetCore.Mvc;

namespace Mkt.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var catalogs = new string[]
            {
                "IPhone 13",
                "IPhone 12",
                "TV LG 8K",
                "Phone JBL",
                "Notebook Dell"
            };

            return Ok(catalogs);
        }
    }
}
