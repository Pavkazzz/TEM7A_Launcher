﻿using System;
using System.ComponentModel.Composition;
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
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public string DbPath { get; set; }
    }
}