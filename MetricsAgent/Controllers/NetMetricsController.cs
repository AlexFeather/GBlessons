using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.Metrics;
using MetricsAgent.Repos;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetMetricsController : ControllerBase
    {
        private NetMetricsRepository repository;
        private readonly IMapper mapper;

        [HttpPost("create")]
        public IActionResult Create([FromBody] NetMetricCreateRequest request)
        {
            repository.Create(new Metrics.NetMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            IList<NetMetric> metrics = repository.GetAll();

            var response = new AllNetMetricResponse()
            {
                Metrics = new List<NetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(mapper.Map<NetMetricDto>(metric));
            }

            return Ok(response);
        }
    }
}