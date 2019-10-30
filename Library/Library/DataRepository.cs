using BaseData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;

namespace DataRepoName
{
    public class DataRepository
    {
        public DataRepository()
        {

            _libraryDataBase = new DataContext();

            _libraryDataBase.Incidents.CollectionChanged += IncidentsModyfied;
        }

        #region CRUDmethods

        public BookTypeInfo GetBookType(Guid guid)
        {
            BookType tempBookType = _libraryDataBase.BookTypes[guid];
            return new BookTypeInfo(tempBookType.BookGuid, tempBookType.Title, tempBookType.Author, tempBookType.NumberOfPages);
        }

        public IEnumerable<BookTypeInfo> GetAllTypes()
        {
            List<BookTypeInfo> bookTypeInfos = new List<BookTypeInfo>();
            foreach (KeyValuePair<Guid, BookType> pair in _libraryDataBase.BookTypes)
            {
                bookTypeInfos.Add(new BookTypeInfo(pair.Key, pair.Value.Title, pair.Value.Author,
                    pair.Value.NumberOfPages));
            }

            return bookTypeInfos;
        }

        public Guid AddType(string title, string author, int numberOfPages)
        {
            Guid freshGuid = new Guid();
            _libraryDataBase.BookTypes.Add(freshGuid, new BookType(freshGuid, title, author, numberOfPages));
            return freshGuid;
        }

        public BookUnitInfo GetBookUnit(Guid guid)
        {
            BookUnit bookUnit = _libraryDataBase.BookUnits[guid];
            return new BookUnitInfo(guid, bookUnit.BookType.BookGuid, bookUnit.BookPrintNumber, bookUnit.IsAvailable.ToString());
        }

        public IEnumerable<BookUnitInfo> GetAllBookUnits()
        {
            List<BookUnitInfo> bookUnitInfos = new List<BookUnitInfo>();
            foreach (KeyValuePair<Guid, BookUnit> pair in _libraryDataBase.BookUnits)
            {
                bookUnitInfos.Add(new BookUnitInfo(pair.Key, pair.Value.BookType.BookGuid,
                    pair.Value.BookPrintNumber, pair.Value.IsAvailable.ToString()));
            }

            return bookUnitInfos;
        }

        public Guid AddBookUnit(Guid bookTypeGuid, int bookPrintNumber)
        {
            Guid guid = new Guid();
            _libraryDataBase.BookUnits.Add(guid, new BookUnit(guid, _libraryDataBase.BookTypes[bookTypeGuid], bookPrintNumber));
            return guid;
        }

        public UserInfo GetUser(Guid guid)
        {
            User tempUser = _libraryDataBase.Users[guid];
            return new UserInfo(guid, tempUser.FirstName, tempUser.LastName);
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            List<UserInfo> userInfos = new List<UserInfo>();
            foreach (KeyValuePair<Guid, User> pair in _libraryDataBase.Users)
            {
                userInfos.Add(new UserInfo(pair.Key, pair.Value.FirstName, pair.Value.LastName));
            }

            return userInfos;
        }

        public Guid AddUser(string firstName, string lastName)
        {
            Guid guid = new Guid();
            _libraryDataBase.Users.Add(guid, new User(guid, firstName, lastName));
            return guid;
        }

        public AbsIncidentInfo MakeInfoFromIncident(Incident incident)
        {
            if (incident is Delivery tempDelivery)
            {
                return new DeliveryInfo(incident.IncidentGuid, incident.User.UserGuid, tempDelivery.BookUnit.BookUnitGuid, tempDelivery.WhenOccured, tempDelivery.Cost);
            }

            if (incident is Rent tempRent)
            {
                return new RentInfo(incident.IncidentGuid, incident.User.UserGuid, tempRent.BookUnit.BookUnitGuid, tempRent.WhenOccured, tempRent.EndTime);
            }

            if (incident is Destruction tempDestruction)
            {
                return new DestructionInfo(incident.IncidentGuid, incident.User.UserGuid, tempDestruction.BookUnit.BookUnitGuid, tempDestruction.WhenOccured);
            }

            return null;
        }

        public Guid AddDestruction(Guid userGuid, Guid bookUnitGuid, DateTime whenOccured)
        {
            Guid guid = Guid.NewGuid();
            User tempUser = _libraryDataBase.Users[userGuid];
            BookUnit temBookUnit = _libraryDataBase.BookUnits[bookUnitGuid];
            _libraryDataBase.Incidents.Add(new Destruction(guid, tempUser, temBookUnit, whenOccured));
            return guid;

        }

        public Guid AddRent(Guid userGuid, Guid bookUnitGuid, DateTime whenOccured, DateTime endTime)
        {
            Guid guid = Guid.NewGuid();
            _libraryDataBase.Incidents.Add(new Rent(guid, _libraryDataBase.Users[userGuid], _libraryDataBase.BookUnits[bookUnitGuid], whenOccured, endTime));
            return guid;

        }

        public Guid AddDelivery(Guid userGuid, Guid bookUnitGuid, DateTime whenOccured, float cost)
        {
            Guid guid = Guid.NewGuid();
            User tempUser = _libraryDataBase.Users[userGuid];
            BookUnit temBookUnit = _libraryDataBase.BookUnits[bookUnitGuid];
            _libraryDataBase.Incidents.Add(new Delivery(guid,
                tempUser, 
                temBookUnit, whenOccured, cost));
            return guid;

        }

        public AbsIncidentInfo GetIncident(Guid guid)
        {
            foreach (Incident incident in _libraryDataBase.Incidents)
            {
                if (incident.IncidentGuid == guid)
                {
                    return MakeInfoFromIncident(incident);
                }
            }



            return null;
        }

        public IEnumerable<AbsIncidentInfo> GetAllIncidents()
        {
            List<AbsIncidentInfo> incidentInfos = new List<AbsIncidentInfo>();
            foreach (Incident incident in _libraryDataBase.Incidents)
            {
                incidentInfos.Add(MakeInfoFromIncident(incident));
            }

            return incidentInfos;
        }
        
        #endregion

        #region DataStructs

        public struct BookTypeInfo
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

        public struct BookUnitInfo
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

        public struct UserInfo
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

        public abstract class AbsIncidentInfo
        {
            protected AbsIncidentInfo(Guid incidentGuid, Guid userGuid, Guid bookGuid, DateTime whenOccured)
            {
                IncidetGuid = incidentGuid;
                UserGuid = userGuid;
                BookGuid = bookGuid;
                WhenOccured = whenOccured;
            }

            public Guid IncidetGuid;
            public Guid UserGuid;
            public Guid BookGuid;
            public DateTime WhenOccured;
        }

        public class DeliveryInfo : AbsIncidentInfo
        {
            public DeliveryInfo(Guid incidentGuid, Guid userGuid, Guid bookGuid, DateTime whenOccured, float cost) : base(incidentGuid, userGuid, bookGuid, whenOccured)
            {
                Cost = cost;
            }
            public float Cost;
        }

        public class DestructionInfo : AbsIncidentInfo
        {
            public DestructionInfo(Guid incidentGuid, Guid userGuid, Guid bookGuid, DateTime whenOccured) : base(incidentGuid, userGuid, bookGuid, whenOccured)
            {

            }
        }

        public class RentInfo : AbsIncidentInfo
        {
            public RentInfo(Guid incidentGuid, Guid userGuid, Guid bookGuid, DateTime whenOccured, DateTime endTime) : base(incidentGuid, userGuid, bookGuid, whenOccured)
            {
                EndTime = endTime;
            }
            public DateTime EndTime;
        }

        #endregion


        #endregion


        public void AutoFillRepository(AbsDataFiller absDataFiller)
        {
            absDataFiller.Fill(_libraryDataBase);
        }

        private DataContext _libraryDataBase;

        public class DataContext
        {
            public DataContext()
            {
                Users = new Dictionary<Guid, User>();
                BookTypes = new Dictionary<Guid, BookType>();
                Incidents = new ObservableCollection<Incident>();
                BookUnits = new Dictionary<Guid, BookUnit>();
            }
            public Dictionary<Guid, User> Users { get; set; }
            public Dictionary<Guid, BookType> BookTypes { get; set; }
            public ObservableCollection<Incident> Incidents { get; set; }
            public Dictionary<Guid, BookUnit> BookUnits { get; set; }

        }

        private void IncidentsModyfied(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            if (eventArgs?.NewItems != null)
            {
                Debug.WriteLine("Modyfied Incident " + eventArgs.NewItems[0].ToString());
            }
        }
    }
}
