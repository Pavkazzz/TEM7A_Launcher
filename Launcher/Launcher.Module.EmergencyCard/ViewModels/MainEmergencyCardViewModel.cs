using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.EmergencyCard.ViewModels
{
    [Export(typeof (IModule))]
    public sealed class MainEmergencyCardViewModel : Conductor<IScreen>.Collection.OneActive, IModule
    {

        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        private MainEmergencyCardViewModel(IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;

            GetCategory();

            ActivateItem(IoC.Get<EmergencyCardListViewModel>());
        }

        private void GetCategory()
        {
            CategoryEmergencyListBox = new BindableCollection<CategoryCard>();
            if (File.Exists(Path.GetFullPath(new EmergencyCardAbout().DbPath)))
            {
                var db = new DataBase(Path.GetFullPath(new EmergencyCardAbout().DbPath));
                var category = db.SqlSelect("Select Name from Category",
                    new List<string> {"Name"});
                foreach (var singlecategory in category)
                {
                    CategoryEmergencyListBox.Add(new CategoryCard(singlecategory["Name"]));
                }
            }
        }


        public void Show()
        {
            ActivateItem(IoC.Get<EmergencyCardListViewModel>());
            _eventAggregator.PublishOnBackgroundThread(SelectedCategoryEmergencyListBox);
        }

        public void CloseWindow()
        {
            TryClose();
        }

        #region PropertyForView

        private BindableCollection<CategoryCard> _categoryCard = new BindableCollection<CategoryCard>();
        private CategoryCard _selectedCategory;


        public BindableCollection<CategoryCard> CategoryEmergencyListBox
        {
            get { return _categoryCard; }
            set
            {
                _categoryCard = value;
                NotifyOfPropertyChange(() => CategoryEmergencyListBox);
            }
        }

        public CategoryCard SelectedCategoryEmergencyListBox
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategoryEmergencyListBox);
            }
        } 

        #endregion
    }
}