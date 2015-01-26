using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Model
{
    class Module
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Module(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Module()
        {
            
        }
    }
}
