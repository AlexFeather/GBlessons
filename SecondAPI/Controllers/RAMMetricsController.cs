using System;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecondAPI
{
    [Route("api/metics/ram")]
    [ApiController]
    public class RAMMetricsController : ControllerBase
    {
        [HttpGet("aviable")]
        public IActionResult GetRAMMetrics()
        {
            return Ok();
        }

    }
}
