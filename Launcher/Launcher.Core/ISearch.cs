using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security.Cryptography.X509Certificates;

namespace Launcher.Core
{
    [InheritedExport(typeof(ISearch))]
    public interface ISearch
    {
        List<string> DoSearch(string name);
    }
}