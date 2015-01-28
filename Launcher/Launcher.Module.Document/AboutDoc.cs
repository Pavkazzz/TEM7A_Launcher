using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document
{
    [Export(typeof(IModuleName))]
    class AboutDoc : IModuleName
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }


        AboutDoc()
        {
            Name = @"Модуль нормативные документы";
            Description = @"Супер модуль";
            ViewModel = typeof(MainDocViewModel);
        }
    }
}
