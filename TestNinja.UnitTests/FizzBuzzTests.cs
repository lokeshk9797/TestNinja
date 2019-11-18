using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {
        private FizzBuzz _fizzbuzz;



       
        [Test]
        [TestCase(15,"FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(4, "4")]
        public void GetOutput_NumberDivisibleBy3And5_ReturnsStringFizzBuzz(int number,string expected)
        {
            var result = FizzBuzz.GetOutput(number);
            Assert.That(result, Is.EqualTo(expected));

        }
       
    }
}
