using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(HistoryViewModel))]
    public class HistoryViewModel : Screen
    {
        private IEventAggregator _eventAggregator;


        #region HistoryListView

        private BindableCollection<History> _historyWrapPanel = new BindableCollection<History>();
        private History _selectedHistory = new History();

        public BindableCollection<History> HisoryWrapPanel
        {
            get { return _historyWrapPanel; }
            set
            {
                _historyWrapPanel = value;
                NotifyOfPropertyChange(() => HisoryWrapPanel);
            }
        }

        public History SelectedHistoryItem
        {
            get { return _selectedHistory; }
            set
            {
                _selectedHistory = value;
                NotifyOfPropertyChange(() => SelectedHistoryItem);
            }
        } 
        #endregion

        [ImportingConstructor]
        public HistoryViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }

    public class History
    {
        public string Name { get; set; }

        public History()
        {
            Name = "qwe";
        }
    }
}