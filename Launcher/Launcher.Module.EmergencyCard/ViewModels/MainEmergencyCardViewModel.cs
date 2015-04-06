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
        private MainEmergencyCardViewModel()
        {
            CategoryEmergencyListBox = new BindableCollection<CategoryCard>();
            if (File.Exists(Path.GetFullPath(new EmergencyCardAbout().DbPath)))
            {
                var db = new DataBase(Path.GetFullPath(new EmergencyCardAbout().DbPath));
                var category = db.SqlSelect("Select NameGroup from GroupOfEmergencyCard",
                    new List<string> {"NameGroup"});
                foreach (var singlecategory in category)
                {
                    CategoryEmergencyListBox.Add(new CategoryCard(singlecategory["NameGroup"]));
                }
            }

            ActivateItem(IoC.Get<EmergencyCardListViewModel>());
        }

        public void CloseWindow()
        {
            TryClose();
        }

        #region PropertyForView

        private BindableCollection<CategoryCard> _categoryCard = new BindableCollection<CategoryCard>();

        public BindableCollection<CategoryCard> CategoryEmergencyListBox
        {
            get { return _categoryCard; }
            set
            {
                _categoryCard = value;
                NotifyOfPropertyChange(() => CategoryEmergencyListBox);
            }
        }

        #endregion
    }
}