using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher.Core;

namespace Launcher.Module.Document
{
    [Export(typeof(IModuleName))]
    class AboutDoc : IModuleName
    {
        public string Name { get; set; }
        public string Description { get; set; }

        AboutDoc()
        {
            Name = @"Модуль нормативные документы";
            Description = @"Супер модуль";
        }
    }
}
