using BookYourHoliday.Models;
using Moq;
using NUnit.Framework;
using NUnit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingTest
{
    [TestFixture]
    public class BookingAppTest
    {
        private Reservation _existingReservation;
        private Mock<IReservationRepo> _repository;

        [SetUp]
        public void SetUp()
        {
            _existingReservation = new Reservation
            {
                Id = 1,
                ArrivalDate = ArivalOn(2018, 11, 24),
                DepartureDate = DepartOn(2018, 11, 30),
                Reference = "ref1",
                Status = "status"
            };

            _repository = new Mock<IReservationRepo>();
            _repository.Setup(r => r.GetActiveReservations(1)).Returns(new List<Reservation>
            {
              _existingReservation
            }.AsQueryable());
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var result = ReservationHelper.OverlappingReservationsExist(new Reservation
            {
                Id = 2,
                ArrivalDate = Before(_existingReservation.ArrivalDate, days: 2),
                DepartureDate = Before(_existingReservation.ArrivalDate)
            },
            _repository.Object);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsBeforeExistingBookingAndEndInBookingTime_ReturnRefString()
        {
            var result = ReservationHelper.OverlappingReservationsExist(new Reservation
            {
                Id = 2,
                ArrivalDate = Before(_existingReservation.ArrivalDate, days: 2),
                DepartureDate = Before(_existingReservation.ArrivalDate, days: -1)
            },
            _repository.Object);
            Assert.AreEqual("ref1", result);
        }

        [Test]
        public void BookingStartsInExistingBookingAndEndInBookingTime_ReturnRefString()
        {
            var result = ReservationHelper.OverlappingReservationsExist(new Reservation
            {
                Id = 2,
                ArrivalDate = _existingReservation.ArrivalDate,
                DepartureDate = _existingReservation.DepartureDate
            },
            _repository.Object);
            Assert.AreEqual("ref1", result);
        }

        [Test]
        public void BookingStartsInExistingBookingAndEndAfterBookingTime_ReturnRefString()
        {
            var result = ReservationHelper.OverlappingReservationsExist(new Reservation
            {
                Id = 2,
                ArrivalDate = _existingReservation.ArrivalDate,
                DepartureDate = After(_existingReservation.DepartureDate, 2)
            },
            _repository.Object);
            Assert.AreEqual("ref1", result);
        }

        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = ReservationHelper.OverlappingReservationsExist(new Reservation
            {
                Id = 2,
                ArrivalDate = After(_existingReservation.ArrivalDate, 10),
                DepartureDate = After(_existingReservation.DepartureDate, 10)
            },
            _repository.Object);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsBeforeExistingBookingAndFinishesAfterExistingBooking_ReturnRefString()
        {
            var result = ReservationHelper.OverlappingReservationsExist(new Reservation
            {
                Id = 2,
                ArrivalDate = Before(_existingReservation.ArrivalDate, 10),
                DepartureDate = After(_existingReservation.DepartureDate, 10)
            },
            _repository.Object);
            Assert.AreEqual("ref1", result);
        }

        private DateTime ArivalOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime Before(DateTime arrivalDate, int days = 1)
        {
            return arrivalDate.AddDays(-days);
        }

        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
