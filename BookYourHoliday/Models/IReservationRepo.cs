using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourHoliday.Models
{
    public interface IReservationRepo
    {
        IQueryable<Reservation> GetActiveReservations(int? excludedReservationId = null);
    }
}
