using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Configuration;
using System.Windows.Controls;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{

    [Export(typeof(LauncherViewModel))]
    class LauncherViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<IModule>, IHandle<IScreen>
    {
        private IEventAggregator _eventAggregator;

        public BindableCollection<ModuleItem> ModulesListBox { get; set; }
            
            
            
            
        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            ModulesListBox = new BindableCollection<ModuleItem>();

            ActivateItem(IoC.Get<ModuleListViewModel>());

        }

        //После выбора модулей
        public void Handle(IModule viewModel)
        {
            var moduleslist = Items[0] as ModuleListViewModel;
            if (moduleslist != null)
                foreach (var item in moduleslist.Modules)
                {
                    ModulesListBox.Add(item);    
                }

            ActivateItem((IScreen) viewModel);
        }

        //После изменения иерархии модуля
        public void Handle(IScreen message)
        {
            ActivateItem(message);
        }
    }
}
