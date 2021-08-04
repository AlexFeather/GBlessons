using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SecondAPI;
using Xunit;

namespace SecondAPIUnitTest
{
    public class RAMMetricsTest
    {
        private RAMMetricsController controller;
        private Mock<ILogger<RAMMetricsController>> mock;

        public RAMMetricsTest()
        {
            mock = new Mock<ILogger<RAMMetricsController>>();
            controller = new RAMMetricsController(mock.Object);
        }

        [Fact]
        public void GetRamMetricsTest_ReturnsOk()
        {
            var result = controller.GetRAMMetrics();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
