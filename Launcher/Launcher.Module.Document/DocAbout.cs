using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    internal class DocAbout : IModuleName
    {
        private List<About> _category = new List<About>();
        
        public DocAbout()
        {
            Coloring = Colors.LightGray;
            PositionNumber = 0;
            Name = @"Модуль нормативные документы";
            Description = @"Модуль «Нормативные документы» предназначен для предоставления в интерактивном виде межгосударственных, национальных и отраслевых стандартов, нормативно технической документации, определяющих требования к сложным техническим системам";
            ViewModel = typeof (MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";

            Category.Add(new About("qwe"));
            Category.Add(new About("asd"));
            Category.Add(new About("zcx"));
        }
        public Color Coloring { get; set; }
        public int PositionNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }

        public List<About> Category
        {
            get { return _category; }
            set
            {
                _category = value;
                
            }
        }


        public bool PrimaryCheck()
        {
            return DocCheck.DocumentCheck();
        }


    }


   
}

