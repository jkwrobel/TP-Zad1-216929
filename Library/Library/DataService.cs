using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepoName;
namespace Library
{
    class DataService
    {
        public DataService(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }



        private DataRepository _dataRepository;
    }
}
