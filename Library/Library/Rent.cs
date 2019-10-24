using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Rent : Incident
    {
        Rent(User user, BookUnit bookUnit, DateTime whenOccured, DateTime endTime) : base(user, bookUnit, whenOccured)
        {
            EndTime = endTime;
            if (endTime == DateTime.MinValue)
            {
                bookUnit.IsAvailable = BookUnit.AvailableStatus.Rented;
            }
            else
            {
                if (bookUnit.IsAvailable == BookUnit.AvailableStatus.Yes)
                {
                    bookUnit.IsAvailable = BookUnit.AvailableStatus.Rented;
                }
                else
                {
                    throw new Exception("Book unavailable");
                }
            }

        }

        public DateTime EndTime;
    }
}
