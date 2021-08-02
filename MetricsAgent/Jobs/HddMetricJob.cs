using MetricsAgent.Repos;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private readonly HddMetricsRepository _repository;

        public HddMetricJob(HddMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            DriveInfo dDrive = new DriveInfo("C");
            var FreeSpacePercentile = (int)(dDrive.AvailableFreeSpace / dDrive.TotalSize) * 100;

            _repository.Delete(_repository.GetLast().Id);
            _repository.Create(new Metrics.HddMetric { Value = FreeSpacePercentile });

            return Task.CompletedTask;
        }
    }
}
