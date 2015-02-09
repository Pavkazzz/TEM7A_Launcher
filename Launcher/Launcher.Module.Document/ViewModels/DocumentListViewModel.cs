using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.ViewModels;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(DocumentListViewModel))]
    public class DocumentListViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private IWindowManager _windowManager;

        #region PropertyForView
        private BindableCollection<Category> _file = new BindableCollection<Category>();
        private Category _selectedfile;

        public BindableCollection<Category> FileNameList
        {
            get { return _file; }
            set
            {
                _file = value;
                NotifyOfPropertyChange(() => FileNameList);
            }
        }

        public Category SelectedFileNameList
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
        public DocumentListViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, Category selectedCategory)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;

            var db = new DataBase(Path.GetFullPath(new AboutDoc().DbPath));
            var category = db.SqlSelect(string.Format(@"Select Document.Name from  Document left outer join Category on Category.id == Document.category Where Category.Name = ""{0}""", 
                selectedCategory.Name), new List<string>() { "Name" });
            foreach (var singlecategory in category)
            {
                FileNameList.Add(new Category(singlecategory["Name"]));
            }
        }

        public void ShowDoc()
        {
            //view для документа.
            _windowManager.ShowDialog(IoC.Get<DocumentViewModel>());
        }
    }
    public class DocFile
    {
        public DocFile(string path)
        {
            Path = path;
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