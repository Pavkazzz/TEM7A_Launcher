using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Linq;
using System.Windows.Controls.Primitives;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{
    [Export(typeof (LauncherViewModel))]
    public class LauncherViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<IModule>, IHandle<IScreen>
    {
        public BindableCollection<ModuleItem> ModulesListBox { get; set; }
        private IEventAggregator _eventAggregator;

         
        private readonly IEnumerable<ISearch> _search;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, [ImportMany(typeof(IModuleName))] IEnumerable<IModuleName> aboutModule, MainModel model)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;

            _eventAggregator.Subscribe(this);
            foreach (var moduleName in aboutModule)
            {
                if (moduleName != null)
                model.Modules.Add(new ModuleItem(moduleName));
            }

            ActivateItem(IoC.Get<ModuleListViewModel>());
        }

        public void Search()
        {
            dynamic settings = new ExpandoObject();
            settings.Placement = PlacementMode.Relative;
            settings.PlacementTarget = GetView();
            settings.HorizontalOffset = 165;
            settings.VerticalOffset = 70;
            
            _windowManager.ShowPopup(IoC.Get<SearchPopupViewModel>(), null, settings);
        }

        #region Property
        string _searchString;
        private IWindowManager _windowManager;

        public string TextBoxSearch
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                NotifyOfPropertyChange(() => TextBoxSearch);
            }
        }

        
        #endregion

        #region Handle

        //После выбора модулей
        public void Handle(IModule viewModel)
        {
            //TODO список модулей
            //var moduleslist = Items[0] as ModuleListViewModel;
            //if (moduleslist != null)
            //    foreach (var item in moduleslist.Modules)
            //    {
            //        ModulesListBox.Add(item);
            //    }

            ActivateItem((IScreen)viewModel);
        }

        //После выбора  модуля
        public void Handle(IScreen message)
        {
            ActivateItem(message);
        } 
        #endregion
    }

    public class Search
    {
        public Search()
        {
            
        }

        public Search(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}