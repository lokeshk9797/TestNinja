using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        private Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]

        //An Important attribute
        //[Ignore("When needed to ignore test to focus somewhere else")]
        public void Add_WhenCalled_ReturnsSumOfArguements()
        {
            var result = _math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));

        }


        //[Test]
        //public void Max_FirstArguementIsGreater_ReturnsFirstArguement()
        //{
        //    var result=_math.Max(1, 2);
        //    Assert.That(result, Is.EqualTo(2));
        //}

        //[Test]
        //public void Max_SecondArguementIsGreater_ReturnsSecondArguement()
        //{
        //    var result = _math.Max(1, 2);
        //    Assert.That(result, Is.EqualTo(2));
        //}

        //[Test]
        //public void Max_BothArguementAreEqual_ReturnsSameArguement()
        //{
        //    var result = _math.Max(1, 1);
        //    Assert.That(result, Is.EqualTo(1));
        //}

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnsGreaterArguement(int a, int b, int expected)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUptoLimit()
        {
            var result= _math.GetOddNumbers(5);

            //Most General
            Assert.That(result, Is.Not.Empty);

            //A little Specific
            Assert.That(result.Count, Is.EqualTo(3));

            //Most Specific
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            //More Refactored Specific

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //Some other Assertions
            //Assert.That(result, Is.Ordered);
            //Assert.That(result,Is.Unique);


        }

    }
}
