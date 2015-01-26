using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;


namespace Launcher.Core
{
    [InheritedExport(typeof(IModule))]
    public interface IModule : IHaveDisplayName
    {

    }
}
