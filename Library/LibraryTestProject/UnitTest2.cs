using DataRepoName;
using System;
using System.Linq;
using BaseData;
using DataFiller;
using DataServNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTestProject
{
    [TestClass()]
    public class UnitTest2
    {
        [TestMethod()]
        public void GetBookTypeTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Assert.AreEqual(dataRepository.GetBookType(dataFiller.testBookGuids[0]).BookTypeGuid, dataFiller.testBookGuids[0]);
        }

        [TestMethod()]
        public void GetAllTypesTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Assert.AreEqual(dataRepository.GetAllTypes().Count(), dataFiller.testBookGuids.Length);
        }

        [TestMethod()]
        public void AddTypeTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Guid testTypeGuid = dataRepository.AddType("testTitle", "testAuthor", 42);


            Assert.AreEqual(dataRepository.GetBookType(testTypeGuid).Title, "testTitle");
        }

        [TestMethod()]
        public void GetBookUnitTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Assert.AreEqual(dataRepository.GetBookUnit(dataFiller.testUnitGuids[0]).BookUnitGuid, dataFiller.testUnitGuids[0]);
        }

        [TestMethod()]
        public void GetAllBookUnitsTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Assert.AreEqual(dataRepository.GetAllBookUnits().Count(), dataFiller.testBookGuids.Length);
        }

        [TestMethod()]
        public void AddBookUnitTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Guid testTypeGuid = dataRepository.AddType("testTitle", "testAuthor", 42);
            Guid testUnitGuid = dataRepository.AddBookUnit(testTypeGuid,56);


            Assert.AreEqual(dataRepository.GetBookUnit(testUnitGuid).PrintNumber, 56);
        }

        [TestMethod()]
        public void GetUserTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Assert.AreEqual(dataRepository.GetUser(dataFiller.testUserGuids[0]).UserGuid, dataFiller.testUserGuids[0]);
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Assert.AreEqual(dataRepository.GetAllUsers().Count(), dataFiller.testUserGuids.Length);
        }

        [TestMethod()]
        public void AddUserTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Guid testUserGuid = dataRepository.AddUser("testFirstName", "testLastName");
            
            Assert.AreEqual(dataRepository.GetUser(testUserGuid).FirstName,"testFirstName" );
        }

        [TestMethod()]
        public void AddDestructionTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Guid testUserGuid = dataRepository.AddUser("testFirstName", "testLastName");
            Guid testTypeGuid = dataRepository.AddType("testTitle", "testAuthor", 42);
            Guid testUnitGuid = dataRepository.AddBookUnit(testTypeGuid, 56);

            Guid testRentGuid = dataRepository.AddDestruction(testUserGuid, testUnitGuid, new DateTime(2019, 4, 2, 4, 2, 4));

            Assert.AreEqual(dataRepository.GetIncident(testRentGuid).BookGuid, testUnitGuid);
            Assert.AreEqual(dataRepository.GetIncident(testRentGuid).UserGuid, testUserGuid);
            Assert.AreEqual(dataRepository.GetBookUnit(testUnitGuid).AvailableStatusInfo, BookUnit.AvailableStatus.Destroyed.ToString());
        }

        [TestMethod()]
        public void AddRentTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Guid testUserGuid = dataRepository.AddUser("testFirstName", "testLastName");
            Guid testTypeGuid = dataRepository.AddType("testTitle", "testAuthor", 42);
            Guid testUnitGuid = dataRepository.AddBookUnit(testTypeGuid, 56);

            Guid testRentGuid = dataRepository.AddRent(testUserGuid, testUnitGuid, new DateTime(2019, 4, 2, 4, 2, 4),
                DateTime.MinValue);

            Assert.AreEqual(dataRepository.GetIncident(testRentGuid).BookGuid,testUnitGuid);
            Assert.AreEqual(dataRepository.GetIncident(testRentGuid).UserGuid, testUserGuid);
            Assert.AreEqual(dataRepository.GetBookUnit(testUnitGuid).AvailableStatusInfo, BookUnit.AvailableStatus.Rented.ToString());
        }

        [TestMethod()]
        public void AddDeliveryTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Guid testUserGuid = dataRepository.AddUser("testFirstName", "testLastName");
            Guid testTypeGuid = dataRepository.AddType("testTitle", "testAuthor", 42);
            Guid testUnitGuid = dataRepository.AddBookUnit(testTypeGuid, 56);

            Guid testDeliveryGuid = dataRepository.AddDelivery(testUserGuid, testUnitGuid, new DateTime(2019, 4, 2, 4, 2, 4),4545);

            Assert.AreEqual(dataRepository.GetIncident(testDeliveryGuid).BookGuid, testUnitGuid);
            Assert.AreEqual(dataRepository.GetIncident(testDeliveryGuid).UserGuid, testUserGuid);
            Assert.AreEqual(dataRepository.GetBookUnit(testUnitGuid).AvailableStatusInfo, BookUnit.AvailableStatus.Yes.ToString());
        }

        [TestMethod()]
        public void GetIncidentTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);
            
            Assert.AreEqual(dataRepository.GetIncident(dataFiller.testIncidentGuids[0]).IncidetGuid, dataFiller.testIncidentGuids[0]);
        }

        [TestMethod()]
        public void GetAllIncidentsTest()
        {
            DataRepository dataRepository = new DataRepository();
            AbsDataFiller dataFiller = new RandomFill();
            dataRepository.AutoFillRepository(dataFiller);

            Assert.AreEqual(dataRepository.GetAllIncidents().Count(),dataFiller.testIncidentGuids.Length);
        }

    }
}