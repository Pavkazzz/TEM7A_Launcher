using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    class About9 : IModuleName
    {

        public About9()
        {
            Coloring = (Color)Colors.White;
            PositionNumber = 10;
            Name = @"Устранение неисправностей";
            Description = @"Модуль «УСТРАНЕНИЕ НЕИСПРАВНОСТЕЙ» обеспечивает в интерактивном виде графическое изображение возможных неисправностей локомотива и порядок действий локомотивной бригады для устранения причин, вызвавших аварию";
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