using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{

    [Export(typeof(LauncherViewModel))]
    class LauncherViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }


        [ImportMany(typeof(IModule))]
        public IEnumerable<Lazy<IModule>> getIMain { get; set; }

        public void Test()
        {

            ActivateItem(getIMain.ToList()[0].Value as IScreen);
        }
    }

}
