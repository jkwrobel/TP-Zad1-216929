using System;

namespace BaseData
{
    public class User
    {
        public User(Guid userGuid, string firstName, string lastName)
        {
            UserGuid = userGuid;
            FirstName = firstName;
            LastName = lastName;
        }
        public Guid UserGuid { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}