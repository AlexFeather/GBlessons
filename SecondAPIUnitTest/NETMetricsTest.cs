using Microsoft.AspNetCore.Mvc;
using SecondAPI.Controllers;
using System;
using Xunit;

namespace SecondAPIUnitTest
{
    public class NetworkMetricsTest
    {
        private NETMetricsController controller;

        public NetworkMetricsTest()
        {
            controller = new NETMetricsController();
        }

        [Fact]
        public void GetNetworkMetricsTest_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetNetworkMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
