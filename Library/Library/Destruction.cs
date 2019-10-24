using System;

namespace Library
{
    public class Destruction : Incident
    {
        public Destruction(User user, BookUnit bookUnit, DateTime whenOccured) : base(user, bookUnit,
            whenOccured)
        {
            bookUnit.IsAvailable = BookUnit.AvailableStatus.Destroyed;
        }

    }
}
