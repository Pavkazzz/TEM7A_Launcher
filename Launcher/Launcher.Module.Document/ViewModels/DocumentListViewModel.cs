using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Core.Components;
using Launcher.Core.Components.Document;
using Launcher.Core.HelperClass;
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

        public void ShowDoc(DocFile doc)
        {
            //view для документа.
            //_eventAggregator.PublishOnBackgroundThread(IoC.Get<DocumentViewModel>());

            new OpenDocument().ShowPdf(doc, new DocAbout().DbPath);

        }

        public void Handle(Category message)
        {
            FileNameList.Clear();
            var db = new DataBase(Path.GetFullPath(new DocAbout().DbPath));
            var category = db.SqlSelect(string.Format(@"Select Category.Path, Document.PathName, Document.Name from  Document
                                                        left outer join Category on Category.id == Document.category Where Category.Name = ""{0}""",
                                                        message.Name), new List<string>() { "Name", "PathName", "Path" });
            foreach (var singlecategory in category)
            {
                FileNameList.Add(new DocFile(singlecategory["Name"], Path.GetFullPath(Path.Combine(@"..\..\..\..\File", singlecategory["Path"], singlecategory["PathName"]))));
            }
        }
    }



    public class Category
    {
        public Category()
        {

        }

        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}