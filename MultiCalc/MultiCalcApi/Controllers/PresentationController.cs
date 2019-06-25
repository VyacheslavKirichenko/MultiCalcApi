using System.Web.Mvc;

namespace MultiCalcApi.Controllers
{
    public class PresentationController : Controller
    {
        public ActionResult CalculationPage()
        {
            return View("CalculationPage");
        }
    }
}