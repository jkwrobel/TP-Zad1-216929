using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    internal class DataRepository
    {
        DataRepository()
        {
            LibraryDB = new DataContext();
        }

        private DataContext LibraryDB;


        class DataContext
        {
            public DataContext()
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
    }
}
