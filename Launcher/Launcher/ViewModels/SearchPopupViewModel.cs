using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{
	[Export(typeof(SearchPopupViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class SearchPopupViewModel : Screen
    {
	    private IEventAggregator _eventAggregator;
        private BindableCollection<SearchName> _searchResult = new BindableCollection<SearchName>();
        private SearchName _selectedListBoxSearch;
	    private IEnumerable<ISearch> _search;

	    [ImportingConstructor]
	    public SearchPopupViewModel(IEventAggregator eventAggregator, [ImportMany(typeof(ISearch))] IEnumerable<ISearch> search)
	    {
	        _eventAggregator = eventAggregator;
	        _search = search;

	        

            List<ISearch> searches = new List<ISearch>();
        //    foreach (ISearch singleSearch in _search)
        //    {
        //        searches.Add(singleSearch);
        //    }
        //    foreach (var singleSearch in searches)
        //    {
        //        foreach (var searchResult in singleSearch.DoSearch(IoC.Get<MainModel>().TextBoxSearchString.Name))
        //        {
        //            //SearchResult.Add(new SearchName(searchResult));
        //        }
        //    }
        }

        //К выбранному итему выполняем закрываем
	    public void SelectedField()
	    {
	        TryClose();
	    }


	    public SearchPopupViewModel(string textBoxSearch)
	    {
	        throw new NotImplementedException();
	    }


    }
}
