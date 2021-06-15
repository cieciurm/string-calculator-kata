using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var splitted = numbers.Split(',');

            if (!splitted.Any())
            {
                return 0;
            }

            return splitted
                .Select(x => Convert.ToInt32(x))
                .Sum();
        }
    }
}