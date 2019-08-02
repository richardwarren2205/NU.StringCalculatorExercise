using System;
using System.Linq;

namespace StringCalculatorExercise
{
    /// <summary>
    /// A simple string calculator
    /// </summary>
    public class StringCalculator
    {
        private readonly char[] supportedDelimiters = new char[2] { ',', '\n' };

        /// <summary>
        /// A method to add a collection of numbers from a string representation
        /// </summary>
        /// <param name="numbers">The input</param>
        /// <returns>The sum of the numbers</returns>
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var splitNumbers = numbers.Split(supportedDelimiters);

            if (splitNumbers.Contains(string.Empty))
                throw new ArgumentException();

            return splitNumbers.Sum(n => int.Parse(n));
        }
    }
}
