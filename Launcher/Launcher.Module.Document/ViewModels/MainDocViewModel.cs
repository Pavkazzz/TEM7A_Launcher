using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows.Forms;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Core.Components;
using Launcher.Core.HelperClass;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof (IModule))]
    public sealed class MainDocViewModel : Conductor<IScreen>.Collection.OneActive, IModule
    {
        private IEventAggregator _eventAggregator;
        private IWindowManager _windowManager;

        #region PropertyForView
        private BindableCollection<Category> _category = new BindableCollection<Category>();
        private Category _selectedCategory;

        public BindableCollection<Category> CategoryList
        {
            get { return _category; }
            set
            {
                _category = value;
                NotifyOfPropertyChange(() => CategoryList);
            }
        }

        public Category SelectedCategoryList
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategoryList);
            }
        } 
        #endregion

        [ImportingConstructor]
        public MainDocViewModel()
        {
            CategoryList = new BindableCollection<Category>();
            if (File.Exists(Path.GetFullPath(new DocAbout().DbPath)))
            {
                var db = new DataBase(Path.GetFullPath(new DocAbout().DbPath));
                var category = db.SqlSelect("SELECT Name FROM Category", new List<string>() { "Name" });
                foreach (var singlecategory in category)
                {
                    CategoryList.Add(new Category(singlecategory["Name"]));
                }
            }

            _eventAggregator = IoC.Get<IEventAggregator>();

            ActivateItem(IoC.Get<HistoryViewModel>());
        }
        public void CloseWindow()
        {
            TryClose();
        }
//        public void Handle(Category message)
//        {
//            FileNameList.Clear();
//            var db = new DataBase(Path.GetFullPath(new DocAbout().DbPath));
//            var category = db.SqlSelect(string.Format(@"Select Category.Path, Document.PathName, Document.Name from  Document
//                                                        left outer join Category on Category.id == Document.category Where Category.Name = ""{0}""",
//                                                        message.Name), new List<string>() { "Name", "PathName", "Path" });
//            foreach (var singlecategory in category)
//            {
//                FileNameList.Add(new DocFile(singlecategory["Name"], Path.GetFullPath(Path.Combine(@"..\..\..\..\File", singlecategory["Path"], singlecategory["PathName"]))));
//            }
//        }
        public void ShowDoc(object o)
        {
            //view для документа.
            //_eventAggregator.PublishOnBackgroundThread(IoC.Get<DocumentViewModel>());
            var doc = o as DocFile;
            if (doc != null)
            {
                var db = new Launcher.Core.DataBase(Path.GetFullPath(new DocAbout().DbPath));

                var index = db.SqlSelect("Select id from History order by id desc", new List<string>() { "id" });

                if (index.Count > 0)
                {
                    db.SqlInsert(string.Format("INSERT INTO \"main\".\"History\" (\"DocumentName\",\"DocumentIndex\",\"Path\") VALUES ('{0}','{1}','{2}')", doc.Name, index[0]["id"], doc.Path));
                }
                else
                {
                    db.SqlInsert(string.Format("INSERT INTO \"main\".\"History\" (\"DocumentName\",\"DocumentIndex\",\"Path\") VALUES ('{0}','{1}','{2}')", doc.Name, '1', doc.Path));
                }

                _windowManager.ShowDialog(new DocumentViewModel(doc));
            }
        }
        public void Show()
        {
            ActivateItem(IoC.Get<DocumentListViewModel>());
            _eventAggregator.PublishOnBackgroundThread(SelectedCategoryList);
        }
    }

    
    }