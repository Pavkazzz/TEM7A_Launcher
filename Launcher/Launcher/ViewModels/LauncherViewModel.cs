using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{
    [Export(typeof (LauncherViewModel))]
    public class LauncherViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<IModule>, IHandle<IScreen>
    {
        private IEventAggregator _eventAggregator;

         
        private readonly IEnumerable<ISearch> _search;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, [ImportMany(typeof(IModuleName))] IEnumerable<IModuleName> aboutModule, MainModel model)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            _model = model;

            _eventAggregator.Subscribe(this);

            foreach (var moduleName in aboutModule)
            {
                if (moduleName != null)
                model.Modules.Add(new ModuleItem(moduleName));
            }

            

            ActivateItem(IoC.Get<ModuleListViewModel>());
        }

        public void OpenModule(ModuleItem o)
        {
            foreach (var name in IoC.GetAll<IModule>().Where(name => name.GetType() == o.ViewModel))
            {
                _eventAggregator.PublishOnBackgroundThread(name);
            }
        }


        #region Search

        //http://stackoverflow.com/questions/13609669/caliburn-micro-screen-transition-via-conductor
        //
        public void Search()
        {
            _model.TextBoxSearchString.Name = TextBoxSearch;
            var view = GetView();
            dynamic settings = new ExpandoObject();
            settings.Placement = PlacementMode.Bottom;
            settings.PlacementTarget = GetView() as TextBox;
            settings.HorizontalOffset = 0;
            settings.VerticalOffset = 0;


            _windowManager.ShowPopup(IoC.Get<SearchPopupViewModel>(), null, settings);
        }

        public void Search(string text)
        {
            _model.TextBoxSearchString.Name = TextBoxSearch;

            dynamic settings = new ExpandoObject();
            settings.Placement = PlacementMode.Relative;
            settings.PlacementTarget = GetView();

            settings.HorizontalOffset = 200;
            settings.VerticalOffset = 100;


            _windowManager.ShowPopup(IoC.Get<SearchPopupViewModel>(), null, settings);
        } 
        #endregion

        #region Property
        string _searchString;
        private IWindowManager _windowManager;
        private MainModel _model;
        private BindableCollection<ModuleItem> _myModules;
        private ModuleItem _selectedModule;

        public string TextBoxSearch
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                NotifyOfPropertyChange(() => TextBoxSearch);
            }
        }

        public BindableCollection<ModuleItem> ModulesListBox
        {
            get { return _myModules; }
            set
            {
                _myModules = value;
                NotifyOfPropertyChange(() => ModulesListBox);
            }
        }

        public ModuleItem SelectedModulesListBox
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                NotifyOfPropertyChange(() => ModulesListBox);
            }
        }

        
        #endregion

        #region Handle

        //После выбора модулей
        public void Handle(IModule viewModel)
        {
            //TODO список модулей

            ModulesListBox = _model.Modules;

            ActivateItem((IScreen)viewModel);
        }

        public void Handle(IScreen message)
        {
            ActivateItem(message);
        } 
        #endregion
    }

    public class SearchName
    {
        public SearchName()
        {
            
        }

        public SearchName(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}