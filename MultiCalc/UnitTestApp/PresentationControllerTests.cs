using MultiCalcApi.Controllers;
using NUnit.Framework;
using System.Web.Mvc;


namespace UnitTestApp
{
    [TestFixture]
    class PresentationControllerTests
    {
        [Test]
        public void CalculationPageViewResultNotNull()
        {
            PresentationController controller = new PresentationController();

            ViewResult result = controller.CalculationPage() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void CalculationPageViewEqualCalculationPageCshtml()
        {
            PresentationController controller = new PresentationController();

            ViewResult result = controller.CalculationPage() as ViewResult;

            Assert.AreEqual("CalculationPage", result.ViewName);
        }

    }
}
