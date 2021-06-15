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

        [Fact]
        public void Test1()
        {
            Check.That(1).IsEqualTo(1);
        }
    }
}
