using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
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
            var db = new DataBase(Path.GetFullPath(new AboutDoc().DbPath));
            var select = db.SqlSelect("Select id, DocumentName, DocumentIndex, Path from History order by documentIndex", new List<string>() { "id", "DocumentName", "DocumentIndex", "Path" });
            foreach (var row in select)
            {
                HisoryWrapPanel.Add(new History(row["DocumentName"]));
            }
        }
    }

    public class History
    {
        public string Name { get; set; }

        public History()
        {
            Name = "qwe";
        }

        public History(string name)
        {
            Name = name;
        }
    }
}