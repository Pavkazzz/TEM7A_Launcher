using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About17 : IModuleName
    {

        public About17()
        {
            Coloring = Colors.White;
            PositionNumber = 18;
            Name = @"Продольный профиль участка";
            Description = @"Модуль «ПРОДОЛЬНЫЙ ПРОФИЛЬ УЧАСТКА» обеспечивает локомотивную бригаду информацией о руководящих подъемах и спусках, радиусах кривых, ограничениях скоростей на участках движения поездов. Содержит режимные карты управления локомотивом .";
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