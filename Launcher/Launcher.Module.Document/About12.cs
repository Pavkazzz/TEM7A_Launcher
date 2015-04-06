using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About12 : IModuleName
    {

        public About12()
        {
            Coloring = Colors.White;
            PositionNumber = 13;
            Name = @"Расчет тормозного нажатия";
            Description = @"Модуль «РАСЧЕТ ТОРМОЗНОГО НАЖАТИЯ» предназначен для проведения тормозных расчётов в поездной работе";
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