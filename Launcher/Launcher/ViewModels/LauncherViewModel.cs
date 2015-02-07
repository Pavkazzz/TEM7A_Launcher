using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{
    [Export(typeof (LauncherViewModel))]
    public class LauncherViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<IModule>, IHandle<IScreen>
    {
        public BindableCollection<ModuleItem> ModulesListBox { get; set; }
        

         
        private readonly IEnumerable<ISearch> _search;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator, [ImportMany(typeof(IModuleName))] IEnumerable<IModuleName> aboutModule, MainModel model, [ImportMany(typeof (ISearch))] IEnumerable<ISearch> search)
        {
            eventAggregator.Subscribe(this);
            _search = search;
            foreach (var moduleName in aboutModule)
            {
                if (moduleName != null)
                model.Modules.Add(new ModuleItem(moduleName));
            }

            ActivateItem(IoC.Get<ModuleListViewModel>());
        }

        public void Search()
        {
            List<ISearch> searches = new List<ISearch>();
            foreach (ISearch search in _search)
            {
                searches.Add(search);
            }
            foreach (var search in searches)
            {
                foreach (var searchResult in search.DoSearch(TextBoxSearch))
                {
                    SearchResult.Add(new Search(searchResult));
                }
            }
        }

        #region Property
        string _searchString;
        private BindableCollection<Search> _searchResult = new BindableCollection<Search>();
        private Search _selectedListBoxSearch;

        public string TextBoxSearch
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                NotifyOfPropertyChange(() => TextBoxSearch);
            }
        }

        public BindableCollection<Search> SearchResult
        {
            get { return _searchResult; }
            set
            {
                _searchResult = value;
                NotifyOfPropertyChange(() => SearchResult);
            }
        }

        public Search SelectedListBoxSearch
        {
            get { return _selectedListBoxSearch; }
            set
            {
                _selectedListBoxSearch = value;
                NotifyOfPropertyChange(() => SelectedListBoxSearch);
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