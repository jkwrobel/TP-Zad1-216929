using System;
using DataFiller;
using DataRepoName;
using DataServNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BaseData;


namespace LibraryTestProject
{

    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void GetAllBookUnitInfosTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new ConstantsFill();
            dataRepository.AutoFillRepository(dataFiller);
            DataService dataService = new DataService(dataRepository);

            Assert.AreEqual(dataService.GetAllBookUnitInfos().Count(), dataRepository.GetAllBookUnits().Count());
        }

        [TestMethod()]
        public void GetIncidentInfosForUserTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new ConstantsFill();
            dataRepository.AutoFillRepository(dataFiller);
            DataService dataService = new DataService(dataRepository);

            List<DataRepository.AbsIncidentInfo> incidentInfos = new List<DataRepository.AbsIncidentInfo>(
                dataService.GetIncidentInfosForUser(dataFiller.testUserGuids[0]));
            Assert.AreEqual(incidentInfos[0].UserGuid, dataFiller.testUserGuids[0]);
        }

        [TestMethod()]
        public void AddRentTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new ConstantsFill();
            dataRepository.AutoFillRepository(dataFiller);
            DataService dataService = new DataService(dataRepository);

            Guid rentGuid = dataService.AddRent(dataFiller.testUserGuids[0], dataFiller.testUnitGuids[3],
                new DateTime(2016, 4, 23, 5, 24, 6), DateTime.MinValue);
            Assert.AreEqual(dataRepository.GetIncident(rentGuid).BookGuid, dataFiller.testUnitGuids[3]);
            Assert.AreEqual(dataRepository.GetBookUnit(dataFiller.testUnitGuids[3]).AvailableStatusInfo,
                BookUnit.AvailableStatus.Rented.ToString());
        }

        [TestMethod()]
        public void AddDestructionTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new ConstantsFill();
            dataRepository.AutoFillRepository(dataFiller);
            DataService dataService = new DataService(dataRepository);

            Guid destructionGuid = dataService.AddDestruction(dataFiller.testUserGuids[3], dataFiller.testUnitGuids[3],
                new DateTime(2016, 4, 23, 5, 24, 6));
            Assert.AreEqual(dataRepository.GetIncident(destructionGuid).BookGuid, dataFiller.testUnitGuids[3]);
            Assert.AreEqual(dataRepository.GetBookUnit(dataFiller.testUnitGuids[3]).AvailableStatusInfo,
                BookUnit.AvailableStatus.Destroyed.ToString());
        }

        [TestMethod()]
        public void AddDeliveryTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new ConstantsFill();
            dataRepository.AutoFillRepository(dataFiller);
            DataService dataService = new DataService(dataRepository);

            Guid deliveryGuid = dataService.AddDelivery(dataFiller.testUserGuids[0], dataFiller.testUnitGuids[3],
                new DateTime(2016, 4, 23, 5, 24, 6),46.50f);
            Assert.AreEqual(dataRepository.GetIncident(deliveryGuid).BookGuid, dataFiller.testUnitGuids[3]);
            Assert.AreEqual(dataRepository.GetBookUnit(dataFiller.testUnitGuids[3]).AvailableStatusInfo,
                BookUnit.AvailableStatus.Yes.ToString());
        }

        [TestMethod()]
        public void GetIncidentInfosBetweenDatesTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new ConstantsFill();
            dataRepository.AutoFillRepository(dataFiller);
            DataService dataService = new DataService(dataRepository);
            DataRepository.AbsIncidentInfo incidentInfo = dataRepository.GetIncident(dataFiller.testIncidentGuids[0]);
            Assert.AreEqual(dataService.GetIncidentInfosBetweenDates(
                new DateTime(incidentInfo.WhenOccured.Year, incidentInfo.WhenOccured.Month,
                    incidentInfo.WhenOccured.Day - 1, incidentInfo.WhenOccured.Hour, incidentInfo.WhenOccured.Minute,
                    incidentInfo.WhenOccured.Second), new DateTime(incidentInfo.WhenOccured.Year,
                    incidentInfo.WhenOccured.Month,
                    incidentInfo.WhenOccured.Day + 1, incidentInfo.WhenOccured.Hour, incidentInfo.WhenOccured.Minute,
                    incidentInfo.WhenOccured.Second)).First().WhenOccured, dataRepository.GetIncident(dataFiller.testIncidentGuids[0]).WhenOccured);
        }

        [TestMethod()]
        public void GetBookUnitInfosForBookTypeTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new ConstantsFill();
            dataRepository.AutoFillRepository(dataFiller);
            DataService dataService = new DataService(dataRepository);
            Assert.AreEqual(dataService.GetBookUnitInfosForBookType(dataFiller.testBookGuids[0]).First().BookUnitGuid,
                dataFiller.testUnitGuids[0]);
        }
    }

}
