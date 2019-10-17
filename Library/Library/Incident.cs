using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Incident
    {
        private Incident(AUser userUuid, BookUnit bookUnit, DateTime whenOccured)
        {
            IncidentGuid = Guid.NewGuid();
            User = userUuid;
            BookUnit = bookUnit;
            WhenOccured = whenOccured;
            EndOfIncident = whenOccured.AddDays(14);
        }

        private Guid IncidentGuid { get; }
        private AUser User { get; }
        private BookUnit BookUnit { get; }
        private DateTime WhenOccured { get; }
        private DateTime EndOfIncident { get; }
    }
}