using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Launcher.ViewModel
{
    [Export(typeof(LauncherViewModel))]
    class LauncherViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator, Model model)
        {
            _eventAggregator = eventAggregator;
        }

        public void Start()
        {
            _eventAggregator.PublishOnBackgroundThread("UpdateSuccess");
        }
    }
}
