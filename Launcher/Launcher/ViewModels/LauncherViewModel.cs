using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{

    [Export(typeof(LauncherViewModel))]
    class LauncherViewModel : Conductor<IScreen>.Collection.OneActive 
    {

        [ImportMany(typeof(IModule))]
        public IEnumerable<Lazy<IModule>> ModuleList { get; set; }

        private IEventAggregator _eventAggregator;

        BindableCollection<string> Modules;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Modules = new BindableCollection<string>();
            Modules.Add("Модуль нормативные документы");
           
        }



        public void Test()
        {
            ActivateItem(ModuleList.ToList()[0].Value as IScreen);
        }

        

    }

}
