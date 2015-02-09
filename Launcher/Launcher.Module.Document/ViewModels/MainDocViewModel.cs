using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows.Forms;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof (IModule))]
    public sealed class MainDocViewModel : Conductor<IScreen>.Collection.OneActive, IModule
    {
        private IEventAggregator _eventAggregator;

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

        [Export(typeof(Category))]
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
        public MainDocViewModel(IEventAggregator eventAggregator)
        {
            CategoryList = new BindableCollection<Category>();
            if (File.Exists(Path.GetFullPath(new AboutDoc().DbPath)))
            {
                var db = new DataBase(Path.GetFullPath(new AboutDoc().DbPath));
                var category = db.SqlSelect("SELECT Name FROM Category", new List<string>() { "Name" });
                foreach (var singlecategory in category)
                {
                    CategoryList.Add(new Category(singlecategory["Name"]));
                }
            }

            _eventAggregator = eventAggregator;

            ActivateItem(IoC.Get<HistoryViewModel>());
        }

        public void Show()
        {
            var sel = SelectedCategoryList;
            ActivateItem(IoC.Get<DocumentListViewModel>());
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