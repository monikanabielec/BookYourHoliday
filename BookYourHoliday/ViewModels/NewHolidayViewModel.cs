using BookYourHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookYourHoliday.ViewModels
{
    public class NewHolidayViewModel
    {
        public IEnumerable<HotelTypes> HotelTypes { get; set; }
        public Reservation Reservation { get; set; }
    }
}