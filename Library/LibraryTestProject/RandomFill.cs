using BaseData;
using DataRepoName;
using System;
using System.Text;

namespace DataFiller
{
    internal class RandomFill : AbsDataFiller
    {
        public override void Fill(DataRepository.DataContext dataContext)
        {
            Random randGenerator = new Random();

            testBookGuids = new Guid[4];
            for (int i = 0; i < 4; i++)
            {
                testBookGuids[i] = Guid.NewGuid();
                dataContext.BookTypes.Add(testBookGuids[i], new BookType(testBookGuids[i], RandomString(randGenerator.Next(10), false),
                    RandomString(randGenerator.Next(10), false), randGenerator.Next(50, 500)));
            }

            testUnitGuids = new Guid[4];
            for (int i = 0; i < 4; i++)
            {
                testUnitGuids[i] = Guid.NewGuid();
                dataContext.BookUnits.Add(testUnitGuids[i], new BookUnit(testUnitGuids[i],
                    dataContext.BookTypes[testIncidentGuids[randGenerator.Next(4)]], randGenerator.Next(3, 300)));
            }

            testUserGuids = new Guid[4];
            for (int i = 0; i < 4; i++)
            {
                testUserGuids[i] = Guid.NewGuid();
                dataContext.Users.Add(testUserGuids[i], new User(
                    testUserGuids[i], RandomString(randGenerator.Next(10), false),
                    RandomString(randGenerator.Next(10), false)));
            }

            testIncidentGuids = new Guid[3];
            for (int i = 0; i < 3; i++)
            {
                testIncidentGuids[i] = Guid.NewGuid();
            }
            dataContext.Incidents.Add(new Rent(testIncidentGuids[0], dataContext.Users[testUserGuids[randGenerator.Next(0, 4)]], 
                dataContext.BookUnits[testUnitGuids[randGenerator.Next(0, 2)]],
                new DateTime(randGenerator.Next(2018, 2020), randGenerator.Next(1, 12), randGenerator.Next(1,25),
                    randGenerator.Next(2, 16), randGenerator.Next(3, 49), randGenerator.Next(15, 30)), DateTime.MinValue));

            dataContext.Incidents.Add(new Delivery(testIncidentGuids[1], dataContext.Users[testUserGuids[randGenerator.Next(0, 4)]],
                dataContext.BookUnits[testUnitGuids[randGenerator.Next(0, 4)]], new DateTime(randGenerator.Next(2016, 2018), randGenerator.Next(1, 13),
                    randGenerator.Next(3, 20)),(float)randGenerator.NextDouble() * randGenerator.Next(20, 60)));

            dataContext.Incidents.Add(new Destruction(testIncidentGuids[2], dataContext.Users[testUserGuids[randGenerator.Next(0, 4)]],
                dataContext.BookUnits[testUnitGuids[randGenerator.Next(2, 4)]],
                new DateTime(randGenerator.Next(2018, 2020), randGenerator.Next(1, 12), randGenerator.Next(1, 25),
                    randGenerator.Next(2, 16), randGenerator.Next(3, 49), randGenerator.Next(15, 30))));

        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
