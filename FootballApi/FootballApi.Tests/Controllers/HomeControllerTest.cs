using System.Web.Mvc;
using FootballApi;
using FootballApi.Controllers;
using NUnit.Framework;

namespace FootballApi.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
