using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{
    [Export(typeof (ModuleListViewModel))]
    internal class ModuleListViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private BindableCollection<ModuleItem> _myModules = new BindableCollection<ModuleItem>();
        private ModuleItem _selectedModule;

        #region PropertyForView
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
        #endregion

        [ImportingConstructor]
        public ModuleListViewModel(IEventAggregator eventAggregator, MainModel model)
        {
            _eventAggregator = eventAggregator;
            Modules = model.Modules;
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