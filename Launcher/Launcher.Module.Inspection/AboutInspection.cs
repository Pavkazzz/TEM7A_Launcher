using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Module.Inspection.ViewModels;

namespace Launcher.Module.Inspection
{
    
    internal class AboutInspection : IModuleName
    {
        private AboutInspection()
        {
            Name = @"Модуль приемки локоматива";
            Description = @"Приемка лааллалал";
            ViewModel = typeof (MainInspectionViewModel);
            DbPath = String.Empty;

            //TODO Category
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }
        public List<About> Category { get; set; }
        public bool PrimaryCheck()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
}