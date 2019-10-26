using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData
{
    public class Rent : Incident
    {
        public Rent(Guid guid, User user, BookUnit bookUnit, DateTime whenOccured, DateTime endTime) : base(guid, user, bookUnit, whenOccured)
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
                    throw new Exception("BookType unavailable");
                }
            }

        }

        public DateTime EndTime;
    }
}
