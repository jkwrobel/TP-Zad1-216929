﻿using BaseData;
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

        private Guid AddType(string title, string author, int numberOfPages)
        {
            Guid freshGuid = new Guid();
            _libraryDataBase.BookTypes.Add(freshGuid, new BookType(freshGuid, title, author, numberOfPages));
            return freshGuid;
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

        private Guid AddBookUnit(Guid bookTypeGuid, int bookPrintNumber)
        {
            Guid guid = new Guid();
            _libraryDataBase.BookUnits.Add(guid, new BookUnit(guid, _libraryDataBase.BookTypes[bookTypeGuid], bookPrintNumber));
            return guid;
        }

        private UserInfo GetUser(Guid guid)
        {
            User tempUser = _libraryDataBase.Users[guid];
            return new UserInfo(guid, tempUser.FirstName, tempUser.LastName);
        }

        private IEnumerable<UserInfo> GetAllUsers()
        {
            List<UserInfo> userInfos = new List<UserInfo>();
            foreach (KeyValuePair<Guid, User> pair in _libraryDataBase.Users)
            {
                userInfos.Add(new UserInfo(pair.Key, pair.Value.FirstName, pair.Value.LastName));
            }

            return userInfos;
        }

        private Guid AddUser(string firstName, string lastName)
        {
            Guid guid = new Guid();
            _libraryDataBase.Users.Add(guid, new User(guid, firstName, lastName));
            return guid;
        }

        private IIncidentInfo makeInfoFromIncident(Incident incident)
        {
            if (incident is Delivery tempDelivery)
            {
                return new DeliveryInfo(incident.IncidentGuid, tempDelivery.BookUnit.BookUnitGuid, tempDelivery.WhenOccured, tempDelivery.Cost);
            }

            if (incident is Rent tempRent)
            {
                return new RentInfo(incident.IncidentGuid, tempRent.BookUnit.BookUnitGuid, tempRent.WhenOccured, tempRent.EndTime);
            }

            if (incident is Destruction tempDestruction)
            {
                return new DestructionInfo(incident.IncidentGuid, tempDestruction.BookUnit.BookUnitGuid, tempDestruction.WhenOccured);
            }

            return null;
        }

        private IIncidentInfo GetIncident(Guid guid)
        {
            Incident tempIncident = null;
            foreach (Incident incident in _libraryDataBase.Incidents)
            {
                if (incident.IncidentGuid == guid)
                {
                    return makeInfoFromIncident(incident);
                }
            }



            return null;
        }

        private IEnumerable<IIncidentInfo> GetAllIncidents()
        {
            List<IIncidentInfo> incidentInfos = new List<IIncidentInfo>();
            foreach (Incident incident in _libraryDataBase.Incidents)
            {
                incidentInfos.Add(makeInfoFromIncident(incident));
            }

            return incidentInfos;
        }

        private Guid AddRent(Guid userGuid, Guid bookUnitGuid, DateTime whenOccured, DateTime endTime)
        {
            Guid guid = new Guid();
            _libraryDataBase.Incidents.Add(new Rent(guid, _libraryDataBase.Users[userGuid], _libraryDataBase.BookUnits[bookUnitGuid], whenOccured, endTime));
            return guid;
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
