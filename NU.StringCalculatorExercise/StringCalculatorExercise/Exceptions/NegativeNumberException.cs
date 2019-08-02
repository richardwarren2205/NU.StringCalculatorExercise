using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorExercise.Exceptions
{
    public class NegativeNumberException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeNumberException"/> class.
        /// </summary>
        public NegativeNumberException()
        { }

        // <summary>
        /// Initializes a new instance of the <see cref="NegativeNumberException"/> class.
        /// </summary>
        /// <param name="Message">The message.</param>
        public NegativeNumberException(List<int> numbers) : base($"Negatives not allowed ({string.Join(',', numbers)})")
        { }
    }
}
