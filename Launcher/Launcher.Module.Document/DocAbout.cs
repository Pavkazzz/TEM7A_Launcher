using System;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;


namespace Launcher.Module.Document
{
    internal class DocAbout : IModuleName
    {
        public DocAbout()
        {
            Coloring = Colors.LightGray;
            PositionNumber = 0;
            Name = @"Модуль нормативные документы";
            Description = @"Модуль «Нормативные документы» предназначен для предоставления в интерактивном виде межгосударственных, национальных и отраслевых стандартов, нормативно технической документации, определяющих требования к сложным техническим системам";
            ViewModel = typeof (MainDocViewModel);

            DbPath = "../../../../Launcher.Module.Document/document.sqlite";

        }
        public Color Coloring { get; set; }
        public int PositionNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }



        public bool PrimaryCheck()
        {
            return DocCheck.DocumentCheck();
        }


    }


   
}

