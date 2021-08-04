using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SecondAPI.Controllers;
using System;
using Xunit;

namespace SecondAPIUnitTest
{
    public class NetworkMetricsTest
    {
        private NETMetricsController controller;
        private Mock<ILogger<NETMetricsController>> mock;

        public NetworkMetricsTest()
        {
            mock = new Mock<ILogger<NETMetricsController>>();
            controller = new NETMetricsController(mock.Object);
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
