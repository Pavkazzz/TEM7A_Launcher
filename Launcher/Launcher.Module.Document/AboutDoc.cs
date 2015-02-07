using System;
using System.ComponentModel.Composition;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    [Export(typeof (IModuleName))]
    internal class AboutDoc : IModuleName
    {
        private AboutDoc()
        {
            Name = @"Модуль нормативные документы";
            Description = @"Супер модуль";
            ViewModel = typeof (MainDocViewModel);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
    }
}