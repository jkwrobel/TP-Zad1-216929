﻿using System;
using DataRepoName;
using BaseData;

namespace DataFiller
{
    internal class ConstantsFill : AbsDataFiller
    {
        public override void Fill(DataRepository.DataContext dataContext)
        {
            string[] tempTitles = new[] { "Pan Tadeusz", "Don Kichot", "Don Quixote", "Testeroni Potatoni" };
            string[] tempAuthors = new[] { "Mickiewicz", "Von Ktokolwiek", "Znaczenia vel Toniema", "Jack Smartass" };
            int[] tempPages = new[] { 625, 531, 35, 966 };
            testBookGuids = new Guid[4];
            for (int i = 0; i < 4; i++)
            {
                testBookGuids[i] = Guid.NewGuid();
                dataContext.BookTypes.Add(testBookGuids[i], new BookType(testBookGuids[i], tempTitles[i], tempAuthors[i], tempPages[i]));
            }

            testUnitGuids = new Guid[4];
            for (int i = 0; i < 4; i++)
            {
                testUnitGuids[i] = Guid.NewGuid();
                dataContext.BookUnits.Add(testUnitGuids[i], new BookUnit(testUnitGuids[i], dataContext.BookTypes[testBookGuids[i]], (i + 3) * (i + 2)));
            }

            string[] tempFirstNames = new[] { "Mike", "Jacek", "Grzegorz", "Tom" };
            string[] tempLastNames = new[] { "Tomaszek", "Kowalski", "Enomus", "Foam" };
            testUserGuids = new Guid[4];
            for (int i = 0; i < 4; i++)
            {
                testUserGuids[i] = Guid.NewGuid();
                dataContext.Users.Add(testUserGuids[i], new User(testUserGuids[i], tempFirstNames[i], tempLastNames[i]));
            }

            testIncidentGuids = new Guid[3];
            for (int i = 0; i < 3; i++)
            {
                testIncidentGuids[i] = Guid.NewGuid();
            }
            dataContext.Incidents.Add(new Rent(testIncidentGuids[0], dataContext.Users[testUserGuids[0]], dataContext.BookUnits[testUnitGuids[0]],
                new DateTime(2019, 5, 28, 4, 6, 13), DateTime.MinValue));
            dataContext.Incidents.Add(new Delivery(testIncidentGuids[1], dataContext.Users[testUserGuids[1]],
                dataContext.BookUnits[testUnitGuids[1]], new DateTime(2018, 2, 4), 31.5f));
            dataContext.Incidents.Add(new Destruction(testIncidentGuids[2], dataContext.Users[testUserGuids[2]], dataContext.BookUnits[testUnitGuids[2]],
                new DateTime(2018, 2, 15, 21, 23, 43)));

        }
    }
}
