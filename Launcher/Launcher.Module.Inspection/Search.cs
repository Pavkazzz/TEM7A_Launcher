using System.Collections.Generic;
using Launcher.Core;
using Launcher.Core.HelperClass;

namespace Launcher.Module.Inspection
{
    internal class Search : ISearch
    {
        public string ModuleName
        {
            get { return new AboutInspection().Name; }
        }

        public List<DocFile> DoSearch(string name)
        {
            var result = new List<DocFile>();
            result.Add(new DocFile("Поиск по модулю приемка локоматива: " + name));
            return result;
        }
    }
}