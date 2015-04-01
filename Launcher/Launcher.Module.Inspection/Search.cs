using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher.Core;

namespace Launcher.Module.Inspection
{
    class Search : ISearch
    {
        public string ModuleName
        {
            get { return new AboutInspection().Name; }
        }

        public List<string> DoSearch(string name)
        {
            var result = new List<string>();
            result.Add("Поиск по модулю приемка локоматива: " + name);
            return result;
        }
    }
}
