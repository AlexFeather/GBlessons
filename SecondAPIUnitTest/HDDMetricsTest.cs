using Microsoft.AspNetCore.Mvc;
using SecondAPI.Controllers;
using Xunit;

namespace SecondAPIUnitTest
{
    public class HDDMetricsTest
    {
        private HDDMetricsController controller;
        
        public HDDMetricsTest()
        {
            controller = new HDDMetricsController();
        }

        [Fact]
        public void GetHDDMetricsTest_ReturnsOk()
        {
            var result = controller.GetHDDMetrics();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
