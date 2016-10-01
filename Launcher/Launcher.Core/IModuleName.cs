using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Media;

namespace Launcher.Core
{
    [InheritedExport(typeof (IModuleName))]
    public interface IModuleName
    {
        Color Coloring { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int PositionNumber { get; set; }
        Type ViewModel { get; set; }
        string DbPath { get; set; }
        bool PrimaryCheck();
    }
}