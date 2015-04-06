using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About3 : IModuleName
    {

        public About3()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 5;
            Name = @"Расчёт характеристик электрического тормоза";
            Description = @"Модуль «РАСЧЕТ ХАРАКТЕРИСТИК ЭЛЕКТРИЧЕСКОГО ТОРМОЗА» предназначен для расчета электромеханических характеристик локомотива с электродвигателями постоянного тока с последовательным возбуждением при электрическом торможении";
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