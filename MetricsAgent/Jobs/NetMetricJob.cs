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
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                long bytesDownloaded = 0;
                foreach (NetworkInterface element in interfaces)
                {
                    bytesDownloaded += element.GetIPv4Statistics().BytesReceived;
                }
                long bytesDownloadedLastTime = 0;
                try
                {
                    bytesDownloadedLastTime = _repository.GetLast().Value;
                }
                finally
                {

                }
                var downloadSpeed = (int)(bytesDownloaded - bytesDownloadedLastTime);
                _repository.Create(new Metrics.NetMetric { Value = downloadSpeed, Time = time });
            }
            else
            {

                _repository.Create(new Metrics.NetMetric { Time = time, Value = 0 });
            }

            return Task.CompletedTask;
        }
    }
}
