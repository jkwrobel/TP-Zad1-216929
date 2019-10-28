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

        public IEnumerable<DataRepository.BookUnitInfo> GetAllBookUnitInfosInfos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataRepository.IIncidentInfo> GetIncidentInfosForUser(Guid userGuid)
        {
            throw new NotImplementedException();
        }

        public DataRepository.RentInfo AddRent(Guid bookUnitGuid, Guid userGuid, DateTime whenStarted,
            DateTime endTime)
        {
            throw new NotImplementedException();
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

        public IEnumerable<DataRepository.IIncidentInfo> GetIncidentInfosBetweenDates(DateTime starTime,
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
