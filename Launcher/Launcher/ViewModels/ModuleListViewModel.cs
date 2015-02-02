using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{

    [Export(typeof (ModuleListViewModel))]
    internal class ModuleListViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        private IEnumerable<IModuleName> _aboutModule;

        [ImportMany(typeof(IModule))]
        public IEnumerable<Lazy<IModule>> ModuleList { get; set; }

        private BindableCollection<ModuleItem> _myModules = new BindableCollection<ModuleItem>();
        public BindableCollection<ModuleItem> Modules
        {
            get { return _myModules; }
            set
            {
                _myModules = value;
                NotifyOfPropertyChange(() => Modules);
            }
        }

        private ModuleItem _selectedModule;
        public ModuleItem SelectedModule
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                NotifyOfPropertyChange(() => SelectedModule);
            }
        }

        
        [ImportingConstructor]
        public ModuleListViewModel(IEventAggregator eventAggregator, [ImportMany(typeof(IModuleName))] IEnumerable<IModuleName> aboutModule)
        {
            _eventAggregator = eventAggregator;
            _aboutModule = aboutModule;

            foreach (var module in _aboutModule)
            {
                Modules.Add(new ModuleItem(module.Name, module.Description, module.ViewModel));
            }
        }

        public void OpenModule()
        {
            foreach (var name in IoC.GetAll<IModule>().Where(name => name.GetType() == SelectedModule.ViewModel))
            {
                _eventAggregator.PublishOnBackgroundThread((IModule)name);
            }
        }
    }
}
