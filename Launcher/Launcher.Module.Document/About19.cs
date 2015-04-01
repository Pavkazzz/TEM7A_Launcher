using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About19 : IModuleName
    {

        public About19()
        {
            Coloring = Colors.White;
            PositionNumber = 20;
            Name = @"Аварийная остановка";
            Description = @"Модуль «АВАРИЙНАЯ ОСТАНОВКА» указывает порядок действий локомотивной бригады при аварийной остановке поезда (локомотива)";
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