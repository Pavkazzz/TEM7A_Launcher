using System;
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
    public sealed class EmergencyCardListViewModel : Screen, IHandle<CategoryCard>
    {
        private IEventAggregator _eventAggregator;
        private IWindowManager _windowManager;

        [ImportingConstructor]
        public EmergencyCardListViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            //Тут надо сдeлать,чтобы выводилось изначальное приветствие


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
            var name = e.NameCard;
            var path = e.PathToFile;
            if (e.PathToFile != null)
            {
                Console.WriteLine(name);
                Console.WriteLine(path);
                //new OpenDocument().DialogDocument(new DocFile(name, path), new EmergencyCardAbout().DbPath);
                //new OpenDocument().DialogDocument(new DocFile(name, @"C:\Users\Pavka_000\Source\Repos\Launcher\Launcher\File\EmergencyCard\EmergencyCard101_149\АВАРИЙНАЯ КАРТОЧКА N 101.docx"), new EmergencyCardAbout().DbPath); 
            }
        }
        #region EmergencyListView

        private BindableCollection<EmergencyCardFileClass> _emergencyCardListBox =
            new BindableCollection<EmergencyCardFileClass>();

        public BindableCollection<EmergencyCardFileClass> EmergencyCardListBox
        {
            get { return _emergencyCardListBox; }
            set
            {
                _emergencyCardListBox = value;
                NotifyOfPropertyChange(() => EmergencyCardListBox);
            }
        }

        #endregion

        public void Handle(CategoryCard message)
        {
            EmergencyCardListBox.Clear();
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
            //foreach (var row in select)
            //{
            //    EmergencyCardListBox.Add(new EmergencyCardFileClass(row["Name_Card"], row["Conditional_Number"],
            //        row["Shipping_Name"], row["ClassificationNumber"], Path.GetFullPath(Path.Combine(@"..\..\..\..\File", row["PathToFile"]))));
            //}
            //TODO add category to EmergencyCard table.
            var category = db.SqlSelect(string.Format(@"Select Category.Path, Document.PathName, Document.Name from  Document
                                                        left outer join Category on Category.id == Document.category Where Category.Name = ""{0}""",
                                                        message.CategoryName), new List<string> { "Name", "PathName", "Path" });
            foreach (var singlecategory in category)
            {
                //EmergencyCardListBox.Add(new DocFile(singlecategory["Name"], Path.GetFullPath(Path.Combine(@"..\..\..\..\File", singlecategory["Path"], singlecategory["PathName"]))));
            }
        }
    }
}