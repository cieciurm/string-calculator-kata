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

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("4,5,6", 15)]
        public void Add_WhenNumbersIncludeUnknownNumberOfIntegers_ThenSumsCorrectly(string input, int expected)
        {
             // Act
            var result = Act(input);

            // Assert
            Check.That(result).IsEqualTo(expected);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("4,5\n6", 15)]
        public void Add_WhenNumbersIncludeNewline_ThenSumsCorrectly(string input, int expected)
        {
             // Act
            var result = Act(input);

            // Assert
            Check.That(result).IsEqualTo(expected);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//.\n1.2.3", 6)]
        public void Add_WhenNumbersIncludeDelimiter_ThenSumsCorrectly(string input, int expected)
        {
             // Act
            var result = Act(input);

            // Assert
            Check.That(result).IsEqualTo(expected);
        }

        [Theory]
        [InlineData("-1,2", "Negatives not allowed: -1")]
        [InlineData("2,-4,3,-5", "Negatives not allowed: -4,-5")]
        public void Add_WhenCallingWithNegativeNumber_ThenThrowsExceptionWithPropertMessage(string input, string expectedMessage)
        {
             // Act & Assert
            Check
                .ThatCode(() => Act(input))
                .Throws<Exception>().WithMessage(expectedMessage);
        }

        private int Act(string input) => _calculator.Add(input);
    }
}
