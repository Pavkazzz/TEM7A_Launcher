using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Core
{
    public class ModuleItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }

        public ModuleItem(string name, string description, Type viewModel)
        {
            Name = name;
            Description = description;
            ViewModel = viewModel;
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
