using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Core
{
    [InheritedExport(typeof(IModuleName))]
    public interface IModuleName
    {
        string DisplayName { get; set; }
        string DisplayDescription { get; set; }
    }
}
