using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.Repos;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private HddMetricsRepository repository;
        private readonly IMapper mapper;

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            repository.Create(new Metrics.HddMetric
            {
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            HddMetricResponse response = mapper.Map<HddMetricResponse>(repository.GetLast());
            return Ok(response);
        }
    }
}