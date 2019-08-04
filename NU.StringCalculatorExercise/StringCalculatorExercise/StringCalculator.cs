using StringCalculatorExercise.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorExercise
{
    /// <summary>
    /// A simple string calculator
    /// </summary>
    public class StringCalculator
    {
        private readonly char[] defaultDelimiters = new char[2] { ',', '\n' };

        private const string customDelimiterStart = "//";
        private const char customDelimiterEnd = '\n';
        private const int maxNumberToInclude = 1000;

        /// <summary>
        /// A method to add a collection of numbers from a string representation
        /// </summary>
        /// <param name="numbers">The input</param>
        /// <returns>The sum of the numbers</returns>
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            string[] splitNumbers;

            if (numbers.StartsWith(customDelimiterStart))
                splitNumbers = SplitInputStringWithCustomDelimiter(numbers);
            else
                splitNumbers = numbers.Split(defaultDelimiters);

            var integers = ParseNumberString(splitNumbers);

            var negativeNumbers = integers.Where(i => i < 0).ToList();

            if (negativeNumbers.Any())
                throw new NegativeNumberException(negativeNumbers);

            return integers.Where(i => i <= maxNumberToInclude).Sum();
        }

        private string[] SplitInputStringWithCustomDelimiter(string numbers)
        {
            numbers = numbers.Replace(customDelimiterStart, string.Empty);

            var inputParts = numbers.Split(customDelimiterEnd);

            if (inputParts.Length == 2)
            {
                var customDelimiter = inputParts[0];

                if (customDelimiter.Length > 2 && customDelimiter.StartsWith('[') && customDelimiter.EndsWith(']'))
                    customDelimiter = inputParts[0].Substring(1, inputParts[0].Length - 2);

                return inputParts[1].Split(new string[1] { customDelimiter }, StringSplitOptions.None);
            }
            else
                throw new ArgumentException();
        }

        private List<int> ParseNumberString(string[] splitNumbers)
        {
            try
            {
                return Array.ConvertAll(splitNumbers, Int32.Parse).ToList();
            }
            catch
            {
                throw new ArgumentException();
            }
        }
    }
}
