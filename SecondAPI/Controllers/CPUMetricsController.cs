using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SecondAPI
{
    [Route("api/metics/cpu")]
    [ApiController]
    public class CPUMetricsController : ControllerBase
    {
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCPU([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("from/percentile/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCPUInPercentile([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
