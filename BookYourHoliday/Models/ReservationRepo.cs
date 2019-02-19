using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookYourHoliday.Models
{
    public class ReservationRepo : IReservationRepo
    {
        public IQueryable<Reservation> GetActiveReservations(int? excludedReservationId = null)
        {
            var unitOfWork = new UnitOfWork();

            var reservations =
                           unitOfWork.Query<Reservation>()
                           .Where(
                            b => b.Status != "Cancelled");

            if (excludedReservationId.HasValue)
                reservations = reservations.Where(b => b.Id != excludedReservationId.Value);

            return reservations;
        }
    }
}