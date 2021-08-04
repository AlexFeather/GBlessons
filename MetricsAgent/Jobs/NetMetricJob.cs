using MetricsAgent.Repos;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetMetricJob : IJob
    {
        private INetMetricsRepository _repository;

        public NetMetricJob(INetMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            var downloadSpeedCounter = new PerformanceCounter("NetworkInterface", "Bytes Recieved/sec");
            var downloadSpeed = downloadSpeedCounter.NextValue();
            _repository.Create(new Metrics.NetMetric { Value = (int)downloadSpeed, Time = time });
            return Task.CompletedTask;
        }
    }
}
