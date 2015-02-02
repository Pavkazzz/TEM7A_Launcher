using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher.Core;

namespace Launcher.Model
{
    class ModuleItem
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
    }
}
