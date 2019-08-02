using StringCalculatorExercise;
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
        [InlineData("//#\n3#5#2", 10)] // Step 4
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
    }
}
