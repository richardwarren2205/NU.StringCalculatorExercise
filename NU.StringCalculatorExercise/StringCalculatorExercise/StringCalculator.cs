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

        private const string delimiterStartSyntax = "//";
        private const char delimiterEndSyntax = '\n';        

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

            if (numbers.StartsWith(delimiterStartSyntax))
            {
                numbers = numbers.Replace(delimiterStartSyntax, string.Empty);

                var parts = numbers.Split(delimiterEndSyntax);

                if (parts.Length == 2)
                {
                    var customDelimiter = Convert.ToChar(parts[0]);
                    splitNumbers = parts[1].Split(new char[1] { customDelimiter });
                }
                else
                    throw new ArgumentException();
            }
            else
                splitNumbers = numbers.Split(defaultDelimiters);

            var integers = ParseNumberString(splitNumbers);

            var negativeNumbers = integers.Where(i => i < 0).ToList();

            if (negativeNumbers.Any())
                throw new NegativeNumberException(negativeNumbers);

            return integers.Sum();
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
