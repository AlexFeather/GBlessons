using Microsoft.AspNetCore.Mvc;
using SecondAPI;
using Xunit;

namespace SecondAPIUnitTest
{
    public class RAMMetricsTest
    {
        RAMMetricsController controller;

        public RAMMetricsTest()
        {
            controller = new RAMMetricsController();
        }

        [Fact]
        public void GetRamMetricsTest_ReturnsOk()
        {
            var result = controller.GetRAMMetrics();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
