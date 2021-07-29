using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecondAPI
{
    [Route("api/metics/ram")]
    [ApiController]
    public class RAMMetricsController : ControllerBase
    {
        private readonly ILogger<RAMMetricsController> _logger;

        public RAMMetricsController(ILogger<RAMMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }

        [HttpGet("aviable")]
        public IActionResult GetRAMMetrics()
        {
            return Ok();
        }

    }
}
