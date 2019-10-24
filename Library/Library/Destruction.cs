using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Destruction : Incident
    {
        Destruction(User user, BookUnit bookUnit, DateTime whenOccured) : base(user, bookUnit,
            whenOccured)
        {
            bookUnit.IsAvailable = false;
        }

    }
}
