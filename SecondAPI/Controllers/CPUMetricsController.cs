using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SQLite;
using System.Diagnostics;

namespace SecondAPI
{

    [Route("api/metics/cpu")]
    [ApiController]
    public class CPUMetricsController : ControllerBase
    {
        private readonly ILogger<CPUMetricsController> _logger;
        public CPUMetricsController(ILogger<CPUMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Выполнен метод GetMetricsFromAgent");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Выполнен метод GetMetricsFromCluster");
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCPU([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Выполнен метод GetMetricsFromCPU");
            return Ok();
        }

        [HttpGet("percentile/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCPUInPercentile([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Выполнен метод GetMetricsFromCPUInPercentile");
            return Ok();
        }

        [HttpGet("sql-test")]
        public IActionResult TryToSqlLite()
        {
            string stm = "SELECT SQLITE_VERSION()";


            using (var con = new SQLiteConnection(Startup.ConnectionString))
            {
                con.Open();

                using var cmd = new SQLiteCommand(stm, con);
                string version = cmd.ExecuteScalar().ToString();

                return Ok(version);

            }
        }
    }
}

