using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Launcher.Core
{
    [InheritedExport(typeof(IModuleName))]
    public interface IModuleName
    {
        string Name { get; set; }
        string Description { get; set; }
        Type ViewModel { get; set; }
        string DbPath { get; set; }
        List<About> Category { get; set; } 
        bool PrimaryCheck();
    }

    public class About
    {
        public string Name { get; set; }

        About()
        {
            Name = String.Empty;
        }

        About(string name)
        {
            Name = name;
        }
    }
}