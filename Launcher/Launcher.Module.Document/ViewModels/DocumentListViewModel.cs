using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.ViewModels;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(DocumentListViewModel))]
    public class DocumentListViewModel : Screen, IHandle<Category>
    {
        private IEventAggregator _eventAggregator;
        private IWindowManager _windowManager;

        #region PropertyForView
        private BindableCollection<DocFile> _file = new BindableCollection<DocFile>();
        private DocFile _selectedfile;

        public BindableCollection<DocFile> FileNameList
        {
            get { return _file; }
            set
            {
                _file = value;
                NotifyOfPropertyChange(() => FileNameList);
            }
        }

        public DocFile SelectedFileNameList
        {
            get { return _selectedfile; }
            set
            {
                _selectedfile = value;
                NotifyOfPropertyChange(() => SelectedFileNameList);
            }
        }
        #endregion

        [ImportingConstructor]
        public DocumentListViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            _eventAggregator.Subscribe(this);

        }

        public void ShowDoc()
        {
            //view для документа.
            //_eventAggregator.PublishOnBackgroundThread(IoC.Get<DocumentViewModel>());
            if (SelectedFileNameList != null) 
            _windowManager.ShowDialog(new DocumentViewModel(SelectedFileNameList));
        }

        public void Handle(Category message)
        {
            FileNameList.Clear();
            var db = new DataBase(Path.GetFullPath(new AboutDoc().DbPath));
            var category = db.SqlSelect(string.Format(@"Select Category.Path, Document.PathName, Document.Name from  Document
                                                        left outer join Category on Category.id == Document.category Where Category.Name = ""{0}""",
                                                        message.Name), new List<string>() { "Name", "PathName", "Path" });
            foreach (var singlecategory in category)
            {
                FileNameList.Add(new DocFile(singlecategory["Name"], Path.GetFullPath(Path.Combine(@"..\..\..\..\File", singlecategory["Path"], singlecategory["PathName"]))));
            }
        }
    }

    public class DocFile
    {
        public DocFile(string name)
        {
            Name = name;
            Path = string.Empty;
        }
        
        public DocFile(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public string Name { get; private set; }
        public string Path { get; private set; }
    }
}