using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About15 : IModuleName
    {

        public About15()
        {
            Coloring = Colors.White;
            PositionNumber = 16;
            Name = @"Правила заполнения поездных документов ";
            Description = @"Модуль «ПРАВИЛА ЗАПОЛНЕНИЯ ПОЕЗДНЫХ ДОКУМЕНТОВ» обеспечивает в интерактивном виде описание и правила заполнения поездных документов  (маршрута машиниста, справок, журналов формы ТУ-152)";
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