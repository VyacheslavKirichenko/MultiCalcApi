using System;
using System.Web.Mvc;
using DataAccess.Contexts;

namespace MultiCalcApi.Controllers
{
    public class CalculationController : Controller
    {
        private readonly CalculationContext _calculationContext;
        public CalculationController()
        {
            _calculationContext = new CalculationContext();
        }
        [HttpPost]
        public string GetCalculation(string userName, string firstNum, string secondNum, string operation)
        {
            double result;
            double firstNumber;
            double secondNumber;
            string errorMessage;
            if (double.TryParse(firstNum, out firstNumber) && double.TryParse(secondNum, out secondNumber)
                && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(operation))
            {
                result = Calculate(operation, firstNumber, secondNumber, out errorMessage);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    var personId = (Guid)_calculationContext.GetPersonId(userName);
                    _calculationContext.Calc(personId, firstNum, secondNum, operation, result.ToString());
                    return $"{result}";
                }
                else
                {
                    return errorMessage;
                }
            }

            return "Error parsing values";
        }

        public double Calculate(string operation, double firstNumber, double secondNumber, out string errorMessage)
        {
            double result = 0;
            errorMessage = string.Empty;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        errorMessage = "You can't divide by zero.";
                    }
                    break;

                default:
                    result = 0;
                    errorMessage = "Unsupported operation";
                    break;
            }

            return result;
        }
    }
}