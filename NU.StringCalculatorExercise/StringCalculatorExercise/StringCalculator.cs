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

            if (splitNumbers.Contains(string.Empty) || !splitNumbers.All(s => s.All(char.IsDigit)))
                throw new ArgumentException();

            return splitNumbers.Sum(n => int.Parse(n));
        }
    }
}
