using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher.Core;

namespace Launcher.Module.Inspection
{
    [Export(typeof(IModuleName))]
    class AboutInspection : IModuleName
    {
        public string Name { get; set; }
        public string Description { get; set; }

        AboutInspection()
        {
            Name = @"Модуль приемки локоматива";
            Description = @"Приемка лааллалал";
        }
    }
}
