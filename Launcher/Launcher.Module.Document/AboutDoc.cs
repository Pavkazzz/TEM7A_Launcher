using System;
using System.ComponentModel.Composition;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    internal class AboutDoc : IModuleName
    {
        public AboutDoc()
        {
            Name = @"Модуль нормативные документы";
            Description = @"Супер модуль";
            ViewModel = typeof (MainDocViewModel);
            DbPath = "../../../../Launcher.Module.Document/document.sqlite";
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }
    }
}