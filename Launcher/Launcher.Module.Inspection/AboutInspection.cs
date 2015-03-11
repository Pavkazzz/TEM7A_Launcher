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
        public AboutInspection()
        {
            Name = @"Расчёт характеристик электрического тормоза";
            Description = @"Модуль «РАСЧЕТ ХАРАКТЕРИСТИК ЭЛЕКТРИЧЕСКОГО ТОРМОЗА» обеспечивает расчет электромеханических характеристик локомотива с электродвигателями постоянного тока с последовательным возбуждением при электрическом торможении";
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