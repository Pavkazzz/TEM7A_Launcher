using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{
	[Export(typeof(SearchPopupViewModel))]
    class SearchPopupViewModel : Screen
    {
	    private IEventAggregator _eventAggregator;
        private BindableCollection<Search> _searchResult = new BindableCollection<Search>();
        private Search _selectedListBoxSearch;
	    private IEnumerable<ISearch> _search;

	    [ImportingConstructor]
        SearchPopupViewModel(IEventAggregator eventAggregator, [ImportMany(typeof(ISearch))] IEnumerable<ISearch> search)
	    {
	        _eventAggregator = eventAggregator;
	        _search = search;

            List<ISearch> searches = new List<ISearch>();
            foreach (ISearch singleSearch in _search)
            {
                searches.Add(singleSearch);
            }
            foreach (var singleSearch in searches)
            {
                //foreach (var searchResult in singleSearch.DoSearch(SearchString.Name))
                //{
                //    SearchResult.Add(new Search(searchResult));
                //}
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
    }
}
