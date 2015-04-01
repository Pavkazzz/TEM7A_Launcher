using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About1 : IModuleName
    {

        public About1()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 3;
            Name = @"Руководство по эксплуатации";
            Description = @"Модуль «РУКОВОДСТВО ПО ЭКСПЛУАТАЦИИ» предназначен для предоставления в интерактивном виде технического описания конструкций, узлов и деталей сложных технических систем, а также технические характеристики, правила эксплуатации, технического обслуживания, хранения и утилизации сложных технических систем и их компонентов ";
            ViewModel = typeof (DevelopedModuleViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }
        public Color Coloring { get ; set; }
        public int PositionNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }
        public List<About> Category { get; set; }
        public bool PrimaryCheck()
        {
            throw new NotImplementedException();
        }
    }
}