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

            string[] split;
            if (HasDelimiterSpecified(numbers))
            {
                var splitByEndLine = numbers.Split('\n');
                var delimiter = splitByEndLine[0].Substring(2);

                split = splitByEndLine[1].Split(delimiter);
            }
            else
            {
                split = SplitNumbers(numbers);
            }

            if (!split.Any())
            {
                return 0;
            }

            var convertedNumbers = split.Select(x => Convert.ToInt32(x)).ToList();

            var negativeNumbers = convertedNumbers.Where(n => n < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(',', negativeNumbers)}");
            }

            return convertedNumbers
                .Where(n => n <= MaxNumber)
                .Sum();
        }

        private static bool HasDelimiterSpecified(string numbers) => numbers.StartsWith("//");

        private string[] SplitNumbers(string numbers)
        {
            var separators = new[] { ',', '\n' };

            var split = numbers.Split(separators);

            return split;
        }
    }
}