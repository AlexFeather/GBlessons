using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Responses
{
    public class AllNetMetricResponse
    {
        public IList<NetMetricDto> Metrics { get; set; }
    }

    public class NetMetricDto
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
