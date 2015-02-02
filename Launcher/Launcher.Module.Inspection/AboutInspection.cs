using System;
using System.ComponentModel.Composition;
using Launcher.Core;
using Launcher.Module.Inspection.ViewModels;

namespace Launcher.Module.Inspection
{
    [Export(typeof (IModuleName))]
    internal class AboutInspection : IModuleName
    {
        private AboutInspection()
        {
            Name = @"Модуль приемки локоматива";
            Description = @"Приемка лааллалал";
            ViewModel = typeof (MainInspectionViewModel);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
    }
}