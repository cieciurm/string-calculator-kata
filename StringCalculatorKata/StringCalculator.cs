using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public const int MaxNumber = 1_000;

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

            var convertedNumbers = splitted.Select(x => Convert.ToInt32(x));

            var negativeNumbers = convertedNumbers.Where(n => n < 0);
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(',', negativeNumbers)}");
            }

            return convertedNumbers
                .Where(n => n <= MaxNumber)
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