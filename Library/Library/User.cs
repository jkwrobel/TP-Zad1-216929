using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData
{
    public class User
    {
        public User(string firstName, string lastName)
        {
            UserGuid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }
        public Guid UserGuid { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}