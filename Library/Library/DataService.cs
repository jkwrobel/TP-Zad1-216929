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

        public DataRepository.DestructionInfo AddDestruction(Guid bookUnitGuid, Guid userGuid, DateTime whenStarted)
        {
            throw new NotImplementedException();
        }

        public DataRepository.DeliveryInfo AddDelivery(Guid bookUnitGuid, Guid userGuid, DateTime whenStarted,
            float cost)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataRepository.AbsIncidentInfo> GetIncidentInfosBetweenDates(DateTime starTime,
            DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataRepository.BookUnitInfo> GetBookUnitInfosForBookType(Guid bookTypeGuid)
        {
            throw new NotImplementedException();
        }

        private DataRepository _dataRepository;
    }
}
