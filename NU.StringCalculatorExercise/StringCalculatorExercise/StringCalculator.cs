using System;
using System.Linq;

namespace StringCalculatorExercise
{
    /// <summary>
    /// A simple string calculator
    /// </summary>
    public class StringCalculator
    {
        /// <summary>
        /// A method to add a collection of numbers from a string representation
        /// </summary>
        /// <param name="numbers">The input</param>
        /// <returns>The sum of the numbers</returns>
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var splitNumbers = numbers.Split(',').Select(n => int.Parse(n)).ToList();

            if (splitNumbers.Count > 2)
                throw new ArgumentOutOfRangeException();

            return splitNumbers.Sum();
        }
    }
}
