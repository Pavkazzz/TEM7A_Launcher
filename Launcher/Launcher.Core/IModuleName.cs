using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Launcher.Core
{
    public interface IModuleName
    {
        string Name { get; set; }
        string Description { get; set; }
        Type ViewModel { get; set; }
        // ViewModel { get; set; }
    }
}
