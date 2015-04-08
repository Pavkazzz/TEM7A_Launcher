using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Core.Components.Document;
using Launcher.Core.HelperClass;

namespace Launcher.Module.EmergencyCard.ViewModels
{
    [Export(typeof (EmergencyCardListViewModel))]
    public sealed class EmergencyCardListViewModel : Conductor<IScreen>.Collection.OneActive, IModule
    {
        private IEventAggregator _eventAggregator;
        private IWindowManager _windowManager;

        [ImportingConstructor]
        public EmergencyCardListViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            //Тут надо сдлеать,чтобы выводилось изначальное приветствие
            var db = new DataBase(Path.GetFullPath(new EmergencyCardAbout().DbPath));
            var select =
                db.SqlSelect(
                    "Select Name_Card, Conditional_Number, Shipping_Name, ClassificationNumber, PathToFile from EmergencyCard",
                    new List<string>
                    {
                        "Name_Card",
                        "Conditional_Number",
                        "Shipping_Name",
                        "ClassificationNumber",
                        "PathToFile"
                    });
            foreach (var row in select)
            {
                EmergencyCardListBox.Add(new EmergencyCardFileClass(row["Name_Card"], row["Conditional_Number"],
                    row["Shipping_Name"], row["ClassificationNumber"], row["PathToFile"]));
            }
        }
        

        public void CloseWindow()
        {
            TryClose();
        }
        /// <summary>
        /// Отображение pdf в дальнейшем надо переделать,чтобы всё работало.
        /// </summary>
        /// <param name="e"></param>
        public void OpenDoc(EmergencyCardFileClass e)
        {
            var name = e.Name_Card;
            var path = e.PathToFile;
            if (e.PathToFile != null)
            {
                new OpenDocument().ShowPdf(new DocFile(name, path), new EmergencyCardAbout().DbPath);
            }
        }
        #region EmergencyListView

        private BindableCollection<EmergencyCardFileClass> _EmergencyCardListBox =
            new BindableCollection<EmergencyCardFileClass>();

        public BindableCollection<EmergencyCardFileClass> EmergencyCardListBox
        {
            get { return _EmergencyCardListBox; }
            set
            {
                _EmergencyCardListBox = value;
                NotifyOfPropertyChange(() => EmergencyCardListBox);
            }
        }

        #endregion
    }
}