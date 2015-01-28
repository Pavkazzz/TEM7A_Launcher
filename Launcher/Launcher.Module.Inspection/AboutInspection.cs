using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Module.Inspection.ViewModels;
using Launcher.Module.Inspection.Views;

namespace Launcher.Module.Inspection
{
    [Export(typeof(IModuleName))]
    class AboutInspection : IModuleName
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }

        AboutInspection()
        {
            Name = @"Модуль приемки локоматива";
            Description = @"Приемка лааллалал";
            ViewModel = typeof(MainInspectionViewModel);
        }
    }
}
