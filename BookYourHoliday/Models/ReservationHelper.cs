using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookYourHoliday.Models
{
    public class ReservationHelper
    {
        public static string OverlappingReservationsExist(Reservation reservation, IReservationRepo _repository)
        {
            if (reservation.Status == "Cancelled")
                return string.Empty;

            var reservations = _repository.GetActiveReservations(1);

            var overlappingReservation =
            reservations.FirstOrDefault(
            b =>
            reservation.ArrivalDate < b.DepartureDate && b.ArrivalDate < reservation.DepartureDate);

            return overlappingReservation == null ? string.Empty
            : overlappingReservation.Reference;
        }
    }
}
}