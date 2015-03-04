using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher.Core;

namespace Launcher.Module.Document
{
    class Search : ISearch
    {
        public List<string> DoSearch(string name)
        {
            var result = new List<string>();
            result.Add("Поиск по н.д." + name);
            return result;
        }
    }
}
