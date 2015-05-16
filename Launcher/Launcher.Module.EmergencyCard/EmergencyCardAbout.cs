using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.EmergencyCard.ViewModels;

namespace Launcher.Module.EmergencyCard
{
    public class EmergencyCardAbout : IModuleName
    {
        public EmergencyCardAbout()
        {
            Coloring = Colors.LightGray;
            PositionNumber = 1;
            Name = @"Аварийные карточки";
            Description =
                @"Модуль «Аварийные карточки» предоставляет в интерактивном виде графическое изображение возможных неисправностей локомотива и порядок действий локомотивной бригады для устранения причин,вызвавших аварию.";
            ViewModel = typeof (MainEmergencyCardViewModel);
            DbPath = "../../../../Launcher.Module.EmergencyCard/EmergencyCard.sqlite";
        }

        public Color Coloring { get; set; }
        public int PositionNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }

        public bool PrimaryCheck()
        {
            DoCheck();

            return true;
        }

        private void DoCheck()
        {

            var db = new DataBase(new EmergencyCardAbout().DbPath);
            var docs = db.SqlSelect(@"Select * from EmergencyCard", new List<string>(){"PathToFile"});

            DirectoryInfo di = new DirectoryInfo(Path.GetFullPath(@"..\..\..\..\File\EmergencyCard"));

            DirectoryInfo[] categoryInfo = di.GetDirectories();

            foreach (var fileInfo in categoryInfo)
            {
                var files = fileInfo.GetFiles("*.pdf");
                //TODO PARSER файлов
                foreach (var file in files)
                {
                    var fileInDb = db.SqlSelect(string.Format(@"Select rowid from EmergencyCard where PathToFile like '%{0}%'", file.Name), new List<string> () { "rowid" });
                    if (fileInDb.Count == 0)
                    {
                        var rowidList = db.SqlSelect(string.Format(@"Select rowid from Category where Category.Path like ""%{0}""", file.Directory.Name),
                            new List<string>() { "rowid" });

                        var category = rowidList[0]["rowid"];

                        db.SqlInsert(string.Format(@"Insert Into EmergencyCard (Name, PathToFile, category) Values ('{0}', '{1}', '{2}')",
                            file.Name.Split(new string[] { "N " }, StringSplitOptions.None)[1].Split('.')[0], file.Name, category));
                    }
                }
            }
        }
    }
}