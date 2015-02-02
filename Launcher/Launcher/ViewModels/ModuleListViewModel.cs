using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{
    [Export(typeof (ModuleListViewModel))]
    internal class ModuleListViewModel : Screen
    {
        private readonly IEnumerable<IModuleName> _aboutModule;
        private readonly IEventAggregator _eventAggregator;
        private BindableCollection<ModuleItem> _myModules = new BindableCollection<ModuleItem>();
        private ModuleItem _selectedModule;

        [ImportingConstructor]
        public ModuleListViewModel(IEventAggregator eventAggregator,
            [ImportMany(typeof (IModuleName))] IEnumerable<IModuleName> aboutModule)
        {
            _eventAggregator = eventAggregator;
            _aboutModule = aboutModule;

            foreach (var module in _aboutModule)
            {
                Modules.Add(new ModuleItem(module.Name, module.Description, module.ViewModel));
            }
        }

        public BindableCollection<ModuleItem> Modules
        {
            get { return _myModules; }
            set
            {
                _myModules = value;
                NotifyOfPropertyChange(() => Modules);
            }
        }

        public ModuleItem SelectedModule
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                NotifyOfPropertyChange(() => SelectedModule);
            }
        }

        public void OpenModule()
        {
            foreach (var name in IoC.GetAll<IModule>().Where(name => name.GetType() == SelectedModule.ViewModel))
            {
                _eventAggregator.PublishOnBackgroundThread(name);
            }
        }
    }
}