using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    abstract class AUser
    {
        protected AUser(string firstName, string lastName)
        {
            UserGuid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }
        private Guid UserGuid { get; }
        private string FirstName { get; }
        private string LastName { get; }
        public abstract float ApplyDiscount(float price);
    }
}