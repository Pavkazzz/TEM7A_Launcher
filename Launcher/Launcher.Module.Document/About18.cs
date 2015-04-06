using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About18 : IModuleName
    {

        public About18()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 19;
            Name = @"Расписание движения поездов";
            Description = @"Модуль «РАСПИСАНИЕ ДВИЖЕНИЯ ПОЕЗДОВ» содержит полную информацию о графике движения поезда и помогает машинисту определять режимы движения поезда ";
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