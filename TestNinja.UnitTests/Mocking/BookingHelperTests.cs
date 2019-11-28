using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class BookingHelperTests_OverlappingBookingExists
    {
        private Booking _existingBooking;
        private Mock<IBookingRepository> _bookingRepository;
        [SetUp]
        public void SetUp()
        {
            _existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2019, 1, 15),
                DepartureDate = DepartOn(2019, 1, 20),
                Reference = "a"
            };

            _bookingRepository = new Mock<IBookingRepository>();
            _bookingRepository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking> { _existingBooking }.AsQueryable());
        }
       

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate,days:2),
                DepartureDate = Before(_existingBooking.ArrivalDate, days: 1),
            }, _bookingRepository.Object);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnsExistingBookinReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate,days:1),
                DepartureDate =After(_existingBooking.ArrivalDate),
            }, _bookingRepository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnsExistingBookinReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 1),
                DepartureDate = After(_existingBooking.DepartureDate),
            }, _bookingRepository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }
        [Test]
        public void BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnsExistingBookinReferenceg()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.ArrivalDate),
                DepartureDate = Before(_existingBooking.DepartureDate),
            }, _bookingRepository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }
        [Test]
        public void BookingStartsInTheMiddleOfAnExistingBookingFinishesAfter_ReturnsExistingBookinReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.DepartureDate),
            }, _bookingRepository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }
        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.DepartureDate),
                DepartureDate = After(_existingBooking.DepartureDate,days:2),
            }, _bookingRepository.Object);
            Assert.That(result, Is.Empty);
        }
        [Test]
        public void BookingOverLappedButNewBookingIsCancelled_ReturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 1),
                DepartureDate = After(_existingBooking.DepartureDate),
                Status = "Cancelled"
            }, _bookingRepository.Object);
            Assert.That(result, Is.Empty);
        }
        private DateTime ArriveOn(int year, int month, int date)
        {
            return new DateTime(year, month, date, 14, 0, 0);
        }
        private DateTime DepartOn(int year, int month, int date)
        {
            return new DateTime(year, month, date, 10, 0, 0);
        }
        private DateTime Before(DateTime dateTime,int days=1)
        {
            return dateTime.AddDays(-days);
        }
        private DateTime After(DateTime dateTime,int days=1)
        {
            return dateTime.AddDays(days);
        }
    }
}
