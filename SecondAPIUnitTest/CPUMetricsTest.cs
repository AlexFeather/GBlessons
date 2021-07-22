using Microsoft.AspNetCore.Mvc;
using SecondAPI;
using System;
using Xunit;

namespace SecondAPIUnitTest
{
    public class CPUMetricsTest
    {
        private CPUMetricsController controller;

        public CPUMetricsTest()
        {
            controller = new CPUMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromCluster_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetricsFromCluster(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromCPU_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetricsFromCPU(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromCPUInPercentile_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetricsFromCPUInPercentile(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
