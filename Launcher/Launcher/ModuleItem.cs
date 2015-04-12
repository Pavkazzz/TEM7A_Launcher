using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Launcher.Core;

namespace Launcher
{
    //TODO inheritance from IModuleName
    public class ModuleItem
    {
        public Color Coloring { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }

        public ModuleItem(string name, string description, Type viewModel, Color color)
        {
            Name = name;
            Description = description;
            ViewModel = viewModel;
            Coloring = color;

        }

        public ModuleItem(IModuleName module)
        {
            Name = module.Name;
            Description = module.Description;
            ViewModel = module.ViewModel;
            Coloring = module.Coloring;

        }

        public ModuleItem()
        {
        }

        public ModuleItem(string name)
        {
            Name = name;
        }

    }
}
