using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Modules.Documents
{
    class Search
    {
        private List<string> _searchResultList; 

        public List<string> DoSearch(string searchstring)
        {
            _searchResultList = DatabaseDoc.Search(searchstring);
            return _searchResultList;
        }
    }
}
