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

        #region CRUDmethods

        private void GetBookType()
        {

        }

        private void GetAllTypes()
        {

        }

        private Guid AddType()
        {
            throw new NotImplementedException();
        }

        private void GetBookUnit()
        {

        }

        private void GetAllBookUnits()
        {

        }

        private Guid AddBookUnit()
        {
            throw new NotImplementedException();
        }

        private void GetUser()
        {

        }

        private void GetAllUsers()
        {

        }

        private Guid AddUser()
        {
            throw new NotImplementedException();
        }

        private void GetIncident()
        {

        }

        private void GetAllIncidents()
        {

        }

        private void AddIncident()
        {

        }

        #endregion

        #region IncidentStructs

        private interface IIncidentInfo
        {

        }

        public struct DeliveryInfo : IIncidentInfo
        {

        }

        #endregion


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
