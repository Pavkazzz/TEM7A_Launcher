using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.Inspection.ViewModels
{
    class MainInspectionViewModel: Screen, IModule
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public MainInspectionViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }
}
