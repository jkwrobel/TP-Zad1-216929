using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class DataRepository
    {
        private DataRepository()
        {

            _libraryDataBase = new DataContext();
        }

        public void AutoFillRepository(IDataFiller dataFiller)
        {
            _dataFiller.Fill(_libraryDataBase);
        }

        private DataContext _libraryDataBase;
        private IDataFiller _dataFiller;

        public class DataContext
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
