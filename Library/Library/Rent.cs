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
                bookUnit.IsAvailable = false;
            }
            else
            {
                if (bookUnit.IsAvailable)
                {
                    bookUnit.IsAvailable = false;
                }
                else
                {
                    throw new Exception("Book already rented");
                }
            }

        }

        public DateTime EndTime;
    }
}
