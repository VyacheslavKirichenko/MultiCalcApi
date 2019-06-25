using MultiCalcApi.Controllers;
using NUnit.Framework;


namespace UnitTestApp
{
    [TestFixture]
    public class CalculationControllerTests
    {
        [TestCase("+", 1, 1, 2)]
        [TestCase("+", 2.0, 3.2, 5.2)]
        [TestCase("*", 1, 1, 1)]
        [TestCase("*", 3, 2, 6)]
        [TestCase("*", 2.3, 2, 4.6)]
        [TestCase("/", 6, 2, 3)]
        [TestCase("/", 6.2, 3.1, 2)]
        [TestCase("/", 5, 2, 2.5)]
        [TestCase("-", 6, 2, 4)]
        [TestCase("-", 2, 1, 1)]
        [TestCase("-", 1, 1, 0)]
        public void Check_Succsesfull_Test(string operation, double firstNumber, double secondNumber,  double expectedResult)
        {
            var calculationController = new CalculationController();
            string errorMessage;
            var  calculationResult = calculationController.Calculate(operation, firstNumber, secondNumber, out errorMessage);

            Assert.AreEqual(calculationResult, expectedResult);
            Assert.AreEqual(errorMessage, "");
        }

        [TestCase("!", 2, 2, "Unsupported operation")]
        [TestCase("/", 2, 0, "You can't divide by zero.")]
        public void Check_Unsuccsesfull_Test(string operation, double firstNumber, double secondNumber,  string expectederrorMessage)
        {
            var calculationController = new CalculationController();
            string errorMessage;
            var calculationResult = calculationController.Calculate(operation, firstNumber, secondNumber, out errorMessage);

            Assert.AreEqual(errorMessage, expectederrorMessage);
        }
    }
}
