using DataAccess.Contexts;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MultiCalcApi.Controllers
{
    public class PersonController : Controller
    {
        private readonly CalculationContext _calculationContext;
        public PersonController()
        {
            _calculationContext = new CalculationContext();
        }

        [HttpGet]
        public JsonResult GetCalculationPerson(string userName)
        {
            var id = (Guid)_calculationContext.GetPersonId(userName);
            var person = _calculationContext.GetPersonData(id);
            return Json(new
            {
                UserName = person.Name,
                History = person.Calculations.Select(x => new
                {
                    firstNumber = x.NumberA,
                    secondNumber = x.NumberB,
                    operation = x.Op,
                    result = x.Result
                })
            }, JsonRequestBehavior.AllowGet);
            //Example http://localhost:55646/Person/GetCalculationPerson?userName=Dimas
        }
    }
}