using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Caliburn.Micro;
using Launcher.Core;

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
                var category = db.SqlSelect("SELECT Name FROM Category", new List<string> { "Name" });
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


        public void Show()
        {
            ActivateItem(IoC.Get<DocumentListViewModel>());
            _eventAggregator.PublishOnBackgroundThread(SelectedCategoryList);
        }
    }

    
    }