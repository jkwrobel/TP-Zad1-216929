using System;
using System.Xml.Serialization;

namespace BaseData
{
    [Serializable]
    [XmlInclude(typeof(Rent))]
    [XmlInclude(typeof(Destruction))]
    [XmlInclude(typeof(Delivery))]
    public abstract class Incident
    {
        protected Incident(Guid guid, User user, BookUnit bookUnit, DateTime whenOccured)
        {
            IncidentGuid = guid;
            User = user;
            BookUnit = bookUnit;
            WhenOccured = whenOccured;
        }

        public Guid IncidentGuid { get; }
        public User User { get; }
        public BookUnit BookUnit { get; }
        public DateTime WhenOccured { get; }


    }
}