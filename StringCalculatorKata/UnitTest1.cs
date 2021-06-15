using System;
using Xunit;
using NFluent;

namespace StringCalculatorKata
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Check.That(1).IsEqualTo(1);
        }
    }
}
