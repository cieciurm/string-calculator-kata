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

            string[] splitted;
            if (HasDelimiterSpecified(numbers))
            {
                var splittedByEndLine = numbers.Split('\n');
                var delimiter = splittedByEndLine[0].Substring(2);

                splitted = splittedByEndLine[1].Split(delimiter);
            }
            else
            {
                splitted = SplitNumbers(numbers);
            }

            if (!splitted.Any())
            {
                return 0;
            }

            return splitted
                .Select(x => Convert.ToInt32(x))
                .Sum();
        }

        private bool HasDelimiterSpecified(string numbers) => numbers.StartsWith("//");

        private string[] SplitNumbers(string numbers)
        {
            var separators = new[] { ',', '\n' };

            var splitted = numbers.Split(separators);

            return splitted;

        }
    }
}