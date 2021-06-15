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

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void Add_WhenNumbersInclude0_1_2Integers_ThenSumsCorrectly(string input, int expected)
        {
             // Act
            var result = Act(input);

            // Assert
            Check.That(result).IsEqualTo(expected);
        }

        private int Act(string input) => _calculator.Add(input);
    }
}
