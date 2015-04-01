using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About4 : IModuleName
    {

        public About4()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 6;
            Name = @"“€говые расчЄты";
            Description = @"ћодуль Ђ“я√ќ¬џ≈ –ј—„≈“џї предназначен дл€ выполнени€ т€говых расчетов в соответствии с Ђѕравилами т€говых расчетов дл€ поездной работыї и представление результатов расчетов в графическом и табличном видах";
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