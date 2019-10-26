using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData
{
    public class Delivery : Incident
    {
        public Delivery(Guid guid, User user, BookUnit bookUnit, DateTime whenOccured, float cost) : base(guid, user, bookUnit, whenOccured)
        {
            Cost = cost;
        }

        public float Cost { get; }
    }
}
