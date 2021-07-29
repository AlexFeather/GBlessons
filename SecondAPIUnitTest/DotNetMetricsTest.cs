using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SecondAPI.Controllers;
using System;
using Xunit;

namespace SecondAPIUnitTest
{
    public class DotNetMetricsTest
    {
        private DotNetMetricsController controller;
        private Mock<ILogger<DotNetMetricsController>> mock;

        public DotNetMetricsTest()
        {
            mock = new Mock<ILogger<DotNetMetricsController>>();
            controller = new DotNetMetricsController(mock.Object);
        }


        [Fact]
        public void GetDotnetMetrics_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetDotnetMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
