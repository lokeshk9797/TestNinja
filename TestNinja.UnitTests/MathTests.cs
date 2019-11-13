using NUnit.Framework;
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

    }
}
