﻿using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Model
{
    public class MainModel
    {
        public BindableCollection<ModuleItem> Modules { get; set; }
        public ModuleItem SelectedModule { get; set; }

        public MainModel()
        {
            Modules = new BindableCollection<ModuleItem>();
            SelectedModule = new ModuleItem();
        }
    }
}