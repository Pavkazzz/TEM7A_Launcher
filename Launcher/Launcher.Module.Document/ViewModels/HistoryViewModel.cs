﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Core.HelperClass;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(HistoryViewModel))]
    public class HistoryViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private IWindowManager _windowManager;

        #region DocFileListView

        private BindableCollection<DocFile> _HistoryWrapPanel = new BindableCollection<DocFile>();
        private DocFile _selectedHistory;


        public BindableCollection<DocFile> HistoryWrapPanels
        {
            get { return _HistoryWrapPanel; }
            set
            {
                _HistoryWrapPanel = value;
                NotifyOfPropertyChange(() => HistoryWrapPanels);
            }
        }

        public DocFile SelectedHistoryWrapPanel
        {
            get { return _selectedHistory; }
            set
            {
                _selectedHistory = value;
                NotifyOfPropertyChange(() => SelectedHistoryWrapPanel);
            }
        } 
        #endregion

        [ImportingConstructor]
        public HistoryViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            var db = new DataBase(Path.GetFullPath(new DocAbout().DbPath));
            var select = db.SqlSelect("Select id, DocumentName, DocumentIndex, Path from History order by documentIndex", new List<string> { "id", "DocumentName", "DocumentIndex", "Path" });
            foreach (var row in select)
            {
                HistoryWrapPanels.Add(new DocFile(row["DocumentName"], row["Path"]));
            }
        }

        public void OpenDoc(DocFile e)
        {
            var name = e.Name;
            var path = e.Path;
            new OpenDocument().ShowPdf(e, new DocAbout().DbPath);
        }
    }
}