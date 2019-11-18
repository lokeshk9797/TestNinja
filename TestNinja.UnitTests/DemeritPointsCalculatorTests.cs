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
    class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;
        
        [SetUp]
        public void Setup()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPoints_SpeedLessThan0_ThrowsOutOfRangeException()
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(-1),Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_SpeedGreaterThan300_ThrowsOutOfRangeException()
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(301), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(40,0)]
        [TestCase(65,0)]
        public void CalculateDemeritPoints_SpeedBelowSpeedLimit_Returns0(int speed, int demeritPoints)
        {
            var result=_demeritPointsCalculator.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(demeritPoints));
        }

        [Test]
        [TestCase(66,0)]
        [TestCase(69,0)]
        public void CalculateDemeritPoints_SpeedAboveSpeedLimitButBelowFirstDemeritValue_Returns0(int speed,int demeritPoints)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(demeritPoints));
        }




        [Test]
        [TestCase(70,1)]
        [TestCase(80,3)]
        [TestCase(300,47)]
        public void CalculateDemeritPoints_SpeedAboveSpeedLimit_ReturnsDemeritPoints(int speed,int demeritPoints)
        {
            var result=_demeritPointsCalculator.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(demeritPoints));
        }
       
    }
}
