using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;
using MahApps.Metro.Controls;

namespace Launcher.ViewModels
{
    [Export(typeof(FlyoutSearchViewModel))]
    class FlyoutSearchViewModel : FlyoutBaseViewModel
    {
        private string _searchString;
        private BindableCollection<SearchName> _searchResult = new BindableCollection<SearchName>();
        private List<ISearch> _searches;
        private BindableCollection<ModuleSearchName> _module = new BindableCollection<ModuleSearchName>();

        [ImportingConstructor]
        public FlyoutSearchViewModel([ImportMany(typeof(ISearch))] IEnumerable<ISearch> search)
        {
            this.Header = "Search";
            this.Position = Position.Right;
            this.FlyoutWidth = 400;


            _searches = search.ToList();


            foreach (var singlesearch in _searches)
            {
                Module.Add(new ModuleSearchName(singlesearch.ModuleName));
            }

            foreach (var searchResult in _searches.SelectMany(singleSearch => singleSearch.DoSearch("")))
            {
                SearchResultList.Add(new SearchName(searchResult));
            }
        }

        public void Search(string searchstring)
        {
            SearchResultList.Clear();
            foreach (var searchResult in _searches.SelectMany(singleSearch => singleSearch.DoSearch(searchstring)))
            {
                SearchResultList.Add(new SearchName(searchResult));
            }
        }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                NotifyOfPropertyChange(() => SearchString);
            }
        }

        public BindableCollection<ModuleSearchName> Module
        {
            get { return _module; }
            set
            {
                _module = value;
                NotifyOfPropertyChange(() => Module);
            }
        }

        public BindableCollection<SearchName> SearchResultList
        {
            get { return _searchResult; }
            set
            {
                _searchResult = value;
                NotifyOfPropertyChange(() => SearchResultList);
            }
        }
    }

    public class ModuleSearchName
    {
        public string ModuleName {get; set; }

        public ModuleSearchName(string module)
        {
            ModuleName = module;
        }


    }
}
