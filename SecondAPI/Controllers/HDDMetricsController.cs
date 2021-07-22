using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SecondAPI.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HDDMetricsController : ControllerBase
    {
        [HttpGet("left")]
        public IActionResult GetHDDMetrics()
        {
            return Ok();
        }

    }
}