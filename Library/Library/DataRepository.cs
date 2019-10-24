using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    internal class DataRepository
    {
        private class DataContext
        {
            private DataContext()
            {
                Users = new Dictionary<Guid, User>();
                BookTypes = new Dictionary<Guid, BookType>();
                Incidents = new ObservableCollection<Incident>();
                BookUnits = new Dictionary<Guid, BookUnit>();
            }
            public Dictionary<Guid, User> Users;
            public Dictionary<Guid, BookType> BookTypes;
            public ObservableCollection<Incident> Incidents;
            public Dictionary<Guid, BookUnit> BookUnits;

        }

        private DataContext dataContext;

    }
}
