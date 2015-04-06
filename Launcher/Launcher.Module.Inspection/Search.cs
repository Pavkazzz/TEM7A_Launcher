using System.Collections.Generic;
using Launcher.Core;

namespace Launcher.Module.Inspection
{
    internal class Search : ISearch
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