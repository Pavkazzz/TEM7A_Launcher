using System;
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
    }
}