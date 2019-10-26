using System;

namespace BaseData
{
    public class Destruction : Incident
    {
        public Destruction(Guid guid, User user, BookUnit bookUnit, DateTime whenOccured) : base(guid, user, bookUnit,
            whenOccured)
        {
            bookUnit.IsAvailable = BookUnit.AvailableStatus.Destroyed;
        }

    }
}
