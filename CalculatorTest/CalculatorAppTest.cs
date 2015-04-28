using System;
using CalculatorKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorAppTest
    {
        [TestMethod]
        public void AddTwoNumbers_Should_Be_Sum()
        {
            //arrange
            CalculatorApp calculatorApp = new CalculatorApp();
            //act
            calculatorApp.Input("2");
            calculatorApp.Input("+");
            calculatorApp.Input("3");            
            var actualResult = calculatorApp.GetAnswer();
            //assert
            var expectedResult = 5;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SubtractTwoNumbers_Should_Be_Difference()
        {
            //arrange
            CalculatorApp calculatorApp = new CalculatorApp();
            //act
            calculatorApp.Input("5");
            calculatorApp.Input("-");
            calculatorApp.Input("3");
            var actualResult = calculatorApp.GetAnswer();
            //assert
            var expectedResult = 2;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MultiplyTwoNumbers_Should_Be_Product()
        {
            //arrange
            CalculatorApp calculatorApp = new CalculatorApp();
            //act
            calculatorApp.Input("5");
            calculatorApp.Input("*");
            calculatorApp.Input("3");
            var actualResult = calculatorApp.GetAnswer();
            //assert
            var expectedResult = 15;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DivideTwoNumbers_Should_Be_Quotient()
        {
            //arrange
            CalculatorApp calculatorApp = new CalculatorApp();
            //act
            calculatorApp.Input("6");
            calculatorApp.Input("/");
            calculatorApp.Input("3");
            var actualResult = calculatorApp.GetAnswer();
            //assert
            var expectedResult = 2;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ComputeThreeNumbers_Should_Be_Sum_And_Product()
        {
            //arrange
            CalculatorApp calculatorApp = new CalculatorApp();
            //act
            calculatorApp.Input("2");
            calculatorApp.Input("+");
            calculatorApp.Input("3");
            calculatorApp.Input("*");
            calculatorApp.Input("4");
            var actualResult = calculatorApp.GetAnswer();
            //assert
            var expectedResult = 20;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ComputeFourNumbers_Should_Be_Sum_And_Product_And_Quotient()
        {
            //arrange
            CalculatorApp calculatorApp = new CalculatorApp();
            //act
            calculatorApp.Input("2");
            calculatorApp.Input("+");
            calculatorApp.Input("3");
            calculatorApp.Input("*");
            calculatorApp.Input("4");
            calculatorApp.Input("/");
            calculatorApp.Input("2");
            var actualResult = calculatorApp.GetAnswer();
            //assert
            var expectedResult = 10;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ComputeWithDecimalNumbers_Should_Be_Sum_And_Product_And_Quotient()
        {
            //arrange
            CalculatorApp calculatorApp = new CalculatorApp();
            //act
            calculatorApp.Input("2");
            calculatorApp.Input(".");
            calculatorApp.Input("5");
            calculatorApp.Input("+");
            calculatorApp.Input("3");
            calculatorApp.Input(".");
            calculatorApp.Input("5");
            calculatorApp.Input("*");
            calculatorApp.Input("10");
            calculatorApp.Input(".");
            calculatorApp.Input("1");
            calculatorApp.Input("/");
            calculatorApp.Input("2");
            var actualResult = calculatorApp.GetAnswer();
            //assert
            double expectedResult = 30.3;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddTwoNumbersWithTwoDigitsEach_Should_Be_Sum()
        {
            //arrange
            CalculatorApp calculatorApp = new CalculatorApp();
            //act
            calculatorApp.Input("2");
            calculatorApp.Input("4");
            calculatorApp.Input("+");
            calculatorApp.Input("3");
            calculatorApp.Input("5");
            var actualResult = calculatorApp.GetAnswer();
            //assert
            var expectedResult = 59;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ComputeWithMoreThanOneDigitAndDecimalNumbers_Should_Be_Sum_And_Product_And_Quotient()
        {
            //arrange
            CalculatorApp calculatorApp = new CalculatorApp();
            //act
            calculatorApp.Input("2");
            calculatorApp.Input("4");
            calculatorApp.Input(".");
            calculatorApp.Input("5");
            calculatorApp.Input("9");
            calculatorApp.Input("+");
            calculatorApp.Input("3");
            calculatorApp.Input("8");
            calculatorApp.Input(".");
            calculatorApp.Input("5"); 
            calculatorApp.Input("4");
            calculatorApp.Input("*");
            calculatorApp.Input("10");
            calculatorApp.Input(".");
            calculatorApp.Input("1");
            calculatorApp.Input("/");
            calculatorApp.Input("2");
            var actualResult = calculatorApp.GetAnswer();
            //assert
            double expectedResult = 318.8;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
