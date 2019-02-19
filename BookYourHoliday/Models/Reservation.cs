using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookYourHoliday.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int HotelId { get; set; }

        [Display(Name = "Arrival Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime ArrivalDate { get; set; }

        [Display(Name = "Departure Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime DepartureDate { get; set; }

        public string Status { get; set; }
        public string Reference { get; set; }

        public virtual HotelTypes HotelTypes { get; set; }

    }
}