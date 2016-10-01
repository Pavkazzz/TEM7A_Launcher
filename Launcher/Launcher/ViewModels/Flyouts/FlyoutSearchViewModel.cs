using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Core.Components.Document;
using Launcher.Core.HelperClass;
using MahApps.Metro.Controls;

namespace Launcher.ViewModels
{
    [Export(typeof(FlyoutSearchViewModel))]
    class FlyoutSearchViewModel : FlyoutBaseViewModel
    {
        private string _searchString;
        private BindableCollection<SearchName> _searchResult = new BindableCollection<SearchName>();
        private List<ISearch> _searches;
        private IWindowManager _windowManager;
        private BindableCollection<ModuleSearchName> _module = new BindableCollection<ModuleSearchName>();

        [ImportingConstructor]
        public FlyoutSearchViewModel(IWindowManager windowManager, [ImportMany(typeof(ISearch))] IEnumerable<ISearch> search)
        {
            Header = "Поиск";
            Position = Position.Right;
            FlyoutWidth = 400;

            _windowManager = windowManager;
            _searches = search.ToList();

            //TODO TreeView
            foreach (var singlesearch in _searches)
            {
                Module.Add(new ModuleSearchName(singlesearch.ModuleName));
            }

            foreach (var searchResult in _searches.SelectMany(singleSearch => singleSearch.DoSearch("")))
            {
                SearchResultList.Add(new SearchName(searchResult.Name, searchResult.Path));
            }
        }

        public void Search(string searchstring)
        {
            SearchResultList.Clear();
            foreach (var searchResult in _searches.SelectMany(singleSearch => singleSearch.DoSearch(searchstring)))
            {
                SearchResultList.Add(new SearchName(searchResult.Name, searchResult.Path));
            }
        }

        public void OpenSearch(SearchName o)
        {
            if (o.Name == "" || o.FilePath == "") return;
            
            Console.WriteLine(o.FilePath);

            var open = new OpenDocument();

            open.DialogDocument(new DocFile(o.Name, o.FilePath),"");
            
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

    public class SearchName
    {
        public SearchName()
        {

        }

        public SearchName(string name, string path)
        {
            Name = name;
            FilePath = path;
        }

        public string FilePath { get; set; }
        public string Name { get; set; }
    }
}
