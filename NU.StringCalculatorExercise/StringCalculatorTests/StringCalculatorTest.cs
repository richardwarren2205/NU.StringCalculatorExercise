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
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("2,9,3", 14)]
        [InlineData("1,2,3,4,5", 15)]        
        public void Step1Test_ValidInput(string input, int expected)
        {
            var count = _stringCalculator.Add(input);

            Assert.Equal(count, expected);
        }

        // No longer required after adding Step 2 functionality
        //[Fact]
        //public void Step1Test_Invalid()
        //{
        //    var input = "1,2,3,4";

        //    Assert.Throws<ArgumentOutOfRangeException>(() => _stringCalculator.Add(input));
        //}




    }
}
