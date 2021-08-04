using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SecondAPI.Controllers;
using Xunit;

namespace SecondAPIUnitTest
{
    public class HDDMetricsTest
    {
        private HDDMetricsController controller;
        private Mock<ILogger<HDDMetricsController>> mock;

        public HDDMetricsTest()
        {
            mock = new Mock<ILogger<HDDMetricsController>>();
            controller = new HDDMetricsController(mock.Object);
        }

        [Fact]
        public void GetHDDMetricsTest_ReturnsOk()
        {
            var result = controller.GetHDDMetrics();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
