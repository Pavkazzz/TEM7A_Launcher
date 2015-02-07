using System;

namespace Launcher.Core
{
    public class ModuleItem : IModuleName
    {
        public ModuleItem(string name, string description, Type viewModel)
        {
            Name = name;
            Description = description;
            ViewModel = viewModel;
        }

        public ModuleItem(IModuleName module)
        {
            Name = module.Name;
            Description = module.Description;
            ViewModel = module.ViewModel;
        }

        public ModuleItem()
        {
        }

        public ModuleItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Type ViewModel { get; set; }
    }
}