using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Module.Inspection.ViewModels;

namespace Launcher.Module.Inspection
{
    
    internal class AboutInspection : IModuleName
    {
        public AboutInspection()
        {
            Coloring = Colors.LightGray;
            PositionNumber = 2;
            Name = @"Приемка локомотива";
            Description =
                @"Модуль «ПРИЕМКА ЛОКОМОТИВА» предназначен для проведения приемки и сдачи локомотива, проведения технического обслуживания ТО-1, контроля над последовательностью и выполнением регламентных работ, формирования электронных отчетов";
            ViewModel = typeof (MainInspectionViewModel);
            DbPath = String.Empty;

            //TODO Category
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
            return true;
            //throw new NotImplementedException();
        }
    }
}