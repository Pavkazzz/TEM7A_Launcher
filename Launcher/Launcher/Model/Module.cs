using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher.Core;

namespace Launcher.Model
{
    class Module 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }

        public Module(string name, string description, Type viewModel)
        {
            Name = name;
            Description = description;
            ViewModel = viewModel;
        }

        public Module()
        {
            
        }
    }
}
