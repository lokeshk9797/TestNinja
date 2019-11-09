using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{

    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelled_UserIsAdmin_ReturnsTrue()
        {
            //Arrange 
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert - Method 1
            Assert.IsTrue(result);

        }

        [Test]
        public void CanBeCancelled_SameUserCancels_ReturnsTrue()
        {
            //Arrange 
            var user = new User() { IsAdmin = false };
            var reservation = new Reservation() { MadeBy = user };

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert - Method 2
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelled_DiffrentUserCancels_ReturnsFalse()
        {
            //Arrange 
            var reservation = new Reservation() { MadeBy = new User() };

            //Act
            var result = reservation.CanBeCancelledBy(new User());

            //Assert - Method 3
            Assert.That(result == false);
        }



    }
}
