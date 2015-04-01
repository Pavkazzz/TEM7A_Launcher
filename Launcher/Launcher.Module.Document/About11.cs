using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About11 : IModuleName
    {

        public About11()
        {
            Coloring = Colors.White;
            PositionNumber = 12;
            Name = @"Сервис и техническое обслуживание";
            Description = @"Модуль «СЕРВИС И ТЕХНИЧЕСКОЕ ОБСЛУЖИВАНИЕ» предоставляет в интерактивном виде перечень и порядок проведения работ при выполнении плановых и неплановых видах ремонта сложных технических систем и пошаговый контроль выполнения работ";
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