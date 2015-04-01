using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About13 : IModuleName
    {

        public About13()
        {
            Coloring = Colors.White;
            PositionNumber = 14;
            Name = @"Порядок опробования пневматических тормозов";
            Description = @"Модуль «ПОРЯДОК ОПРОБОВАНИЯ ПНЕВМАТИЧЕСКИХ ТОРМОЗОВ» содержит описание последовательности опробования тормозов (полного и сокращенного), пошаговый  контроль последовательности выполнения опробования тормозов";
            ViewModel = typeof(DevelopedModuleViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }
        public Color Coloring { get; set; }
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