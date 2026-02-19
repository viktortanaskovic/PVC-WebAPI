using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UpitiPVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingAPIController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Alive");
        }
    }
}
