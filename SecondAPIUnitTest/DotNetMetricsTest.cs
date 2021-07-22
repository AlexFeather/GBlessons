using Microsoft.AspNetCore.Mvc;
using SecondAPI.Controllers;
using System;
using Xunit;

namespace SecondAPIUnitTest
{
    public class DotNetMetricsTest
    {
        private DotNetMetricsController controller;

        public DotNetMetricsTest()
        {
            controller = new DotNetMetricsController();
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
