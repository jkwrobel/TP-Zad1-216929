using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Incident
    {
        private Incident(AUser user, BookUnit bookUnit, DateTime whenOccured, DateTime endOfIncident)
        {
            IncidentGuid = Guid.NewGuid();
            User = user;
            BookUnit = bookUnit;
            WhenOccured = whenOccured;
            EndOfIncident = endOfIncident;
        }

        public Guid IncidentGuid { get; }
        public AUser User { get; }
        public BookUnit BookUnit { get; }
        public DateTime WhenOccured { get; }
        public DateTime EndOfIncident { get; }
    }
}