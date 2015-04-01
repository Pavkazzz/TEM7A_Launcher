using System;
using System.Collections.Generic;
using System.Windows.Media;
using Launcher.Core;

namespace Launcher.Model
{
    //TODO inheritance from IModuleName
    public class ModuleItem
    {
        public Color Coloring { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
        public List<About> Category { get; set; } 

        public ModuleItem(string name, string description, Type viewModel, List<About> category, Color color)
        {
            Name = name;
            Description = description;
            ViewModel = viewModel;
            Category = category;
            Coloring = color;

        }

        public ModuleItem(IModuleName module)
        {
            Name = module.Name;
            Description = module.Description;
            ViewModel = module.ViewModel;
            Category = module.Category;
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