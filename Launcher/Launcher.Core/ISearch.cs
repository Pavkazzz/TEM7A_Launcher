using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Launcher.Core
{
    [InheritedExport(typeof (ISearch))]
    public interface ISearch
    {
        string ModuleName { get; }
        List<string> DoSearch(string name);
    }
}