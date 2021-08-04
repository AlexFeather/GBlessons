using MetricsAgent.Repos;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private IDotNetMericsRepository _repository;
        private PerformanceCounter _counter;

        public DotNetMetricJob(IDotNetMericsRepository repository)
        {
            _repository = repository;
            _counter = new PerformanceCounter(""); //пока не понял, что здесь нужно писать
        }
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
