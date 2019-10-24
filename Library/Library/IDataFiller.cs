using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface IDataFiller
    {
        void Fill(List<User> users, Dictionary<Guid, BookType> bookTypes,
            ObservableCollection<Incident> incidents, Dictionary<Guid, BookUnit> bookUnits);

    }
}
