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
            // If input is null or empty, return 0
            if (string.IsNullOrEmpty(numbers))
                return 0;

            string[] splitNumbers;

            // Check to see if the input starts with the custom delimiter notatio - //
            if (numbers.StartsWith(customDelimiterStart))
                splitNumbers = SplitInputStringWithCustomDelimiters(numbers);
            else
                // input is using the default delimiters
                splitNumbers = numbers.Split(defaultDelimiters);

            // Parse the string array into a list of integers
            var integers = ParseNumberString(splitNumbers);

            // Get the negative numbers
            var negativeNumbers = integers.Where(i => i < 0);

            // If any negative numbers exist, throw an exception
            if (negativeNumbers.Any())
                throw new NegativeNumberException(negativeNumbers);

            // Return the sum of all the integers which are less than the maximum value to include - 1000
            return integers.Where(i => i <= maxNumberToInclude).Sum();
        }

        /// <summary>
        /// A method to split the input when a custom delimiter has been specified
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>An array containing all the numbers as a string</returns>
        private string[] SplitInputStringWithCustomDelimiters(string numbers)
        {
            // Remove the custom delimiter starting notation - //
            numbers = numbers.Remove(0, customDelimiterStart.Length);

            // Split the input by the new line notation - \n
            var inputParts = numbers.Split(customDelimiterEnd);

            // Ensure we have 2 sections (Delimiter and number string)
            if (inputParts.Length == 2)
            {
                string[] customDelimiters;

                // Check to see if the delimiter is enclosed inside square brackets
                if (inputParts[0].StartsWith('[') && inputParts[0].EndsWith(']'))
                {
                    // Get the value inside the opening and closing square brackets and then split it into seperate sections by '][' syntax
                    var customDelimiterSection = inputParts[0].Substring(1, inputParts[0].Length - 2);
                    customDelimiters = customDelimiterSection.Split("][");
                }
                else
                    // Delimiter is a simple option. e.g. "//;\n1;2"
                    customDelimiters = new string[1] { inputParts[0] };

                // Return an array containing all the numbers split by the custom delimiter
                return inputParts[1].Split(customDelimiters, StringSplitOptions.None);
            }
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// A method to parse a string array into a List of integers
        /// </summary>
        /// <param name="splitNumbers"></param>
        /// <returns>A List of integers if successful, otherwise an exception is thrown</returns>
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
