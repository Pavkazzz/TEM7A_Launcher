using System.Collections.Generic;
using System.ComponentModel.Composition;
using Launcher.Core.HelperClass;

namespace Launcher.Core
{
    [InheritedExport(typeof (ISearch))]
    public interface ISearch
    {
        string ModuleName { get; }
        List<DocFile> DoSearch(string name);
    }
}