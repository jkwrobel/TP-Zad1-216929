using System;

namespace DataRepoName
{
    public abstract class AbsDataFiller
    {
        public abstract void Fill(DataRepository.DataContext dataContext);
        public Guid[] testBookGuids;
        public Guid[] testUnitGuids;
        public Guid[] testUserGuids;
        public Guid[] testIncidentGuids;


    }
}
