using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData
{
    public class Delivery : Incident
    {
        public Delivery(User user, BookUnit bookUnit, DateTime whenOccured, float cost) : base(user, bookUnit, whenOccured)
        {
            Cost = cost;
        }

        private float Cost { get; }
    }
}
