using Microsoft.AspNetCore.Mvc;
using System;

namespace SecondAPI.Controllers
{
    [Route("api/metics/network")]
    [ApiController]
    public class NETMetricsController : ControllerBase
    {

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetNetworkMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

    }
}