using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookYourHoliday.Models
{
    public class UnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }
}