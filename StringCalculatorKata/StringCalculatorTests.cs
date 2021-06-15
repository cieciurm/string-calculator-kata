using System;
using Xunit;
using NFluent;

namespace StringCalculatorKata
{
    public class StringCalculatorTests
    {
        private StringCalculator _calculator;

        public StringCalculatorTests()
        {
            _calculator = new StringCalculator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Add_WhenReceiveEmptyString_ThenReturnsZero(string input)
        {
            // Act
            var result = Act(input);

            // Assert
            Check.That(result).IsZero();
        }

        private int Act(string input) => _calculator.Add(input);
    }
}
