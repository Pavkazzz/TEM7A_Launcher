using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media;
using Caliburn.Micro;

namespace Launcher.Core
{
    [InheritedExport(typeof(IModuleName))]
    public interface IModuleName
    {
        Color Coloring { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int PositionNumber { get; set; }
        Type ViewModel { get; set; }
        string DbPath { get; set; }
        List<About> Category { get; set; } 
        bool PrimaryCheck();
    }

    public class About
    {
        public string AboutName { get; set; }

        public About()
        {
            AboutName = String.Empty;
        }

        public About(string aboutName)
        {
            AboutName = aboutName;
        }
    }
}