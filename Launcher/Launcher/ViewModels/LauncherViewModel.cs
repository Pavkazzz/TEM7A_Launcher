using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{

    [Export(typeof(LauncherViewModel))]
    class LauncherViewModel : Conductor<IScreen>.Collection.OneActive 
    {

        [ImportMany(typeof(IModule))]
        public IEnumerable<Lazy<IModule>> ModuleList { get; set; }

        private IEventAggregator _eventAggregator;



        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            //Modules = new BindableCollection<Module>{new Module { Name = "Модуль нормативные документы", Description = "111" }};
            Modules = new BindableCollection<Module>();

            //foreach (IModuleName moduleName in ModuleListName)
            //{
            //    Modules.Add(new Module(moduleName.DisplayName, moduleName.DisplayDescription));
            //}
            
        }

        public void Test()
        {
            ActivateItem(ModuleList.ToList()[1].Value as IScreen);
        }

        private BindableCollection<Module> _myModules;
        public BindableCollection<Module> Modules
        {
            get { return _myModules; }
            set
            {
                _myModules = value;
                NotifyOfPropertyChange(() => Modules);
            }
        }

        private Module _selectedModule;
        public Module SelectedModule
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                NotifyOfPropertyChange(() => SelectedModule);
            }
        }
    }
}
