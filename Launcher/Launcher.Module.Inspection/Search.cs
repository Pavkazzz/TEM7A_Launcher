using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Module.Inspection
{
    class Search
    {
        public List<string> DoSearch(string name)
        {
            var result = new List<string>();
            result.Add("Поиск по модулю приемка локоматива: " + name);
            return result;
        }
    }
}
