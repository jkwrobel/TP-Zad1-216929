using DataRepoName;
using System;
using System.Collections.Generic;
namespace DataServNamespace
{
    internal class DataService
    {
        public DataService(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IEnumerable<DataRepository.BookUnitInfo> GetAllBookUnitInfos()
        {
            return _dataRepository.GetAllBookUnits();
        }

        public IEnumerable<DataRepository.AbsIncidentInfo> GetIncidentInfosForUser(Guid userGuid)
        {
            IEnumerable<DataRepository.AbsIncidentInfo> tempInfos = _dataRepository.GetAllIncidents();

            List<DataRepository.AbsIncidentInfo> incidentForUser = new List<DataRepository.AbsIncidentInfo>();
            foreach (DataRepository.AbsIncidentInfo incidentInfo in tempInfos)
            {
                if (incidentInfo.UserGuid != userGuid)
                {
                    incidentForUser.Add(incidentInfo);
                } 
            }

            return incidentForUser;
        }

        public Guid AddRent(Guid bookUnitGuid, Guid userGuid, DateTime whenStarted,
            DateTime endTime)
        {
            return _dataRepository.AddRent( bookUnitGuid, userGuid, whenStarted, endTime);
        }

        public Guid AddDestruction(Guid userGuid, Guid bookUnitGuid, DateTime whenStarted)
        {

            return _dataRepository.AddDestruction(userGuid, bookUnitGuid, whenStarted);
        }

        public Guid AddDelivery(Guid userGuid, Guid bookUnitGuid, DateTime whenStarted,
            float cost)
        {
            return _dataRepository.AddDelivery(userGuid, bookUnitGuid, whenStarted, cost);
        }

        public IEnumerable<DataRepository.AbsIncidentInfo> GetIncidentInfosBetweenDates(DateTime starTime,
            DateTime endTime)
        {
            List<DataRepository.AbsIncidentInfo> incidentInfos = new List<DataRepository.AbsIncidentInfo>(_dataRepository.GetAllIncidents());
            List<DataRepository.AbsIncidentInfo> incidentInfosBetweenDates = new List<DataRepository.AbsIncidentInfo>();
            foreach (DataRepository.AbsIncidentInfo incidentInfo in incidentInfos)
            {
                if (incidentInfo.WhenOccured > starTime && incidentInfo.WhenOccured < endTime)
                {
                    incidentInfosBetweenDates.Add(incidentInfo);
                }
            }

            return incidentInfosBetweenDates;
        }

        public IEnumerable<DataRepository.BookUnitInfo> GetBookUnitInfosForBookType(Guid bookTypeGuid)
        {
            List<DataRepository.BookUnitInfo> bookUnitInfos = new List<DataRepository.BookUnitInfo>(_dataRepository.GetAllBookUnits());_dataRepository.GetAllBookUnits();
            List<DataRepository.BookUnitInfo> bookUnitInfosForType = new List<DataRepository.BookUnitInfo>();
            foreach (DataRepository.BookUnitInfo unitInfo in bookUnitInfos)
            {
                if (unitInfo.BookTypeGuid == bookTypeGuid)
                {
                    bookUnitInfosForType.Add(unitInfo);
                }
            }

            return bookUnitInfosForType;
        }

        private DataRepository _dataRepository;
    }
}
