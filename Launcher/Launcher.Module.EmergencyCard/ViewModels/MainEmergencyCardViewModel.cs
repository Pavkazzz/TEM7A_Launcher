using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;
using System.ComponentModel.Composition;

namespace Launcher.Module.EmergencyCard.ViewModels
{
    [Export(typeof (IModule))]
    public sealed class MainEmergencyCardViewModel : Conductor<IScreen>.Collection.OneActive, IModule
    {
        
    }
}
