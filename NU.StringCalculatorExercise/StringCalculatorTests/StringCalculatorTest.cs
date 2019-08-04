using StringCalculatorExercise;
using StringCalculatorExercise.Exceptions;
using System;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorTest
    {
        private StringCalculator _stringCalculator;

        public StringCalculatorTest()
        {
            _stringCalculator = new StringCalculator();
        }

        [Theory]
        [InlineData("", 0)] // Step 1
        [InlineData(null, 0)] // Step 1
        [InlineData("1", 1)] // Step 1
        [InlineData("1,2", 3)] // Step 1
        [InlineData("1,2,3,4,5", 15)] // Step 2
        [InlineData("1\n2,3", 6)] // Step 3
        [InlineData("1,2\n3", 6)] // Step 3
        [InlineData("//;\n1;2", 3)] // Step 4
        [InlineData("//[\n1[2", 3)] // Step 4
        [InlineData("//#\n3#5#2", 10)] // Step 4
        [InlineData("2,1001", 2)] // Step 6
        [InlineData("2,1001,5", 7)] // Step 6
        [InlineData("//[***]\n1***2***3", 6)] // Step 7
        [InlineData("//[*#$]\n5*#$7*#$9", 21)] // Step 7
        [InlineData("//[[]]\n5[]7[]9", 21)] // Step 7
        [InlineData("//[*][%]\n1*2%3", 6)] // Step 8
        [InlineData("//[*][%][&]\n1*2%3&6", 12)] // Step 8
        [InlineData("//[*][%]\n1*2%3*4", 10)] // Step 8
        public void StringCalculator_ValidInput(string input, int expected)
        {
            var count = _stringCalculator.Add(input);
            Assert.Equal(count, expected);
        }

        [Theory]
        [InlineData("1,\n")] // Step 3
        [InlineData("\n,3,1")] // Step 3
        [InlineData("//;\n1#2")] // Step 4
        public void StringCalculator_InvalidInput(string input)
        {
            Assert.Throws<ArgumentException>(() => _stringCalculator.Add(input));
        }

        [Theory]
        [InlineData("-1,2,3", "Negatives not allowed (-1)")] // Step 5
        [InlineData("-1,5,-7", "Negatives not allowed (-1,-7)")] // Step 5
        public void StringCalculator_NegativeNumberException(string input, string expectedMessage)
        {
            var exception = Assert.Throws<NegativeNumberException>(() => _stringCalculator.Add(input));
            Assert.Equal(expectedMessage, exception.Message);

        }
    }
}
