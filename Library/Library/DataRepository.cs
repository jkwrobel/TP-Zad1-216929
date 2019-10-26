using BaseData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataRepoName
{
    public class DataRepository
    {
        private DataRepository()
        {

            _libraryDataBase = new DataContext();
        }

        #region CRUDmethods

        private BookTypeInfo GetBookType(Guid guid)
        {
            BookType tempBookType = _libraryDataBase.BookTypes[guid];
            return new BookTypeInfo();
        }

        private IEnumerable<BookTypeInfo> GetAllTypes()
        {
            List<BookTypeInfo> bookTypeInfos = new List<BookTypeInfo>();
            foreach (KeyValuePair<Guid, BookType> pair in _libraryDataBase.BookTypes)
            {
                bookTypeInfos.Add(new BookTypeInfo(pair.Key, pair.Value.Title, pair.Value.Author,
                    pair.Value.NumberOfPages));
            }

            return bookTypeInfos;
        }

        private Guid AddType()
        {
            throw new NotImplementedException();
        }

        private BookUnitInfo GetBookUnit(Guid guid)
        {
            BookUnit bookUnit = _libraryDataBase.BookUnits[guid];
            return new BookUnitInfo(guid, bookUnit.BookType.BookGuid, bookUnit.BookPrintNumber, bookUnit.IsAvailable.ToString());
        }

        private IEnumerable<BookUnitInfo> GetAllBookUnits()
        {
            List<BookUnitInfo> bookUnitInfos = new List<BookUnitInfo>();
            foreach (KeyValuePair<Guid, BookUnit> pair in _libraryDataBase.BookUnits)
            {
                bookUnitInfos.Add(new BookUnitInfo(pair.Key, pair.Value.BookType.BookGuid,
                    pair.Value.BookPrintNumber, pair.Value.IsAvailable.ToString()));
            }

            return bookUnitInfos;
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

        private void GetIncident(Guid guid)
        {

        }

        private void GetAllIncidents()
        {

        }

        private Guid AddIncident(Guid unitGuid, Guid userGuid)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region DataStructs

        private struct BookTypeInfo
        {
            public BookTypeInfo(Guid bookGuid, string title, string author, int numberOfPages)
            {
                BookTypeGuid = bookGuid;
                Title = title;
                Author = author;
                NumberOfPages = numberOfPages;
            }
            public Guid BookTypeGuid;
            public string Title;
            public string Author;
            public int NumberOfPages;
        }

        private struct BookUnitInfo
        {
            public BookUnitInfo(Guid bookUnitGuid, Guid bookTypeGuid, int printNumber, string availableStatusInfo)
            {
                BookTypeGuid = bookTypeGuid;
                BookUnitGuid = bookUnitGuid;
                PrintNumber = printNumber;
                AvailableStatusInfo = availableStatusInfo;
            }
            public Guid BookTypeGuid;
            public Guid BookUnitGuid;
            public int PrintNumber;
            public string AvailableStatusInfo;
        }

        private struct UserInfo
        {
            public UserInfo(Guid userGuid, string firstName, string lastName)
            {
                UserGuid = userGuid;
                FirstName = firstName;
                LastName = lastName;
            }

            public Guid UserGuid;
            public string FirstName;
            public string LastName;
        }

        #region IncidentStructs

        private interface IIncidentInfo
        {
        }

        public struct DeliveryInfo : IIncidentInfo
        {
            public DeliveryInfo(Guid userGuid, Guid bookGuid, DateTime whenOccured, float cost)
            {
                UserGuid = userGuid;
                BookGuid = bookGuid;
                WhenOccured = whenOccured;
                Cost = cost;
            }

            public Guid UserGuid;
            public Guid BookGuid;
            public DateTime WhenOccured;
            public float Cost;
        }

        public struct DestructionInfo : IIncidentInfo
        {
            public DestructionInfo(Guid userGuid, Guid bookGuid, DateTime whenOccured)
            {
                UserGuid = userGuid;
                BookGuid = bookGuid;
                WhenOccured = whenOccured;
            }

            public Guid UserGuid;
            public Guid BookGuid;
            public DateTime WhenOccured;
        }

        public struct RentInfo : IIncidentInfo
        {
            public RentInfo(Guid userGuid, Guid bookGuid, DateTime whenOccured, DateTime endTime)
            {
                UserGuid = userGuid;
                BookGuid = bookGuid;
                WhenOccured = whenOccured;
                EndTime = endTime;
            }

            public Guid UserGuid;
            public Guid BookGuid;
            public DateTime WhenOccured;
            public DateTime EndTime;
        }

        #endregion


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
