using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class Incident
    {
        protected Incident(User user, BookUnit bookUnit, DateTime whenOccured)
        {
            IncidentGuid = Guid.NewGuid();
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