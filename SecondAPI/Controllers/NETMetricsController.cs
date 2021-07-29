using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace SecondAPI.Controllers
{
    [Route("api/metics/network")]
    [ApiController]
    public class NETMetricsController : ControllerBase
    {
        private readonly ILogger<NETMetricsController> _logger;

        public NETMetricsController(ILogger<NETMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetNetworkMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

    }
}