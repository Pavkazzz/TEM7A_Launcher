using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof (IModule))]
    public sealed class MainDocViewModel : Conductor<IScreen>.Collection.OneActive, IModule
    {
        private IEventAggregator _eventAggregator;

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
        [ImportingConstructor]
        public MainDocViewModel(IEventAggregator eventAggregator)
        {
            //TODO database, table category.
            CategoryList = new BindableCollection<Category>();
            CategoryList.Add(new Category(@"ГОСТ"));
            CategoryList.Add(new Category(@"ОСТ"));
            CategoryList.Add(new Category(@"ГОСТ Р"));
            CategoryList.Add(new Category(@"ЕСКД"));
            CategoryList.Add(new Category(@"ЕСПД"));


            _eventAggregator = eventAggregator;

            ActivateItem(IoC.Get<HistoryViewModel>());
        }

        public void Show()
        {
            var sel = SelectedCategoryList;
            
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