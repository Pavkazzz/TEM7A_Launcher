using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{
    [Export(typeof (LauncherViewModel))]
    public class LauncherViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<IModule>, IHandle<IScreen>
    {
        public BindableCollection<ModuleItem> ModulesListBox { get; set; }

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator, [ImportMany(typeof(IModuleName))] IEnumerable<IModuleName> aboutModule, MainModel model)
        {
            eventAggregator.Subscribe(this);

            foreach (var moduleName in aboutModule)
            {
                if (moduleName != null)
                model.Modules.Add(new ModuleItem(moduleName));
            }

            ActivateItem(IoC.Get<ModuleListViewModel>());
        }

        //После выбора модулей
        public void Handle(IModule viewModel)
        {
            //TODO список модулей
            //var moduleslist = Items[0] as ModuleListViewModel;
            //if (moduleslist != null)
            //    foreach (var item in moduleslist.Modules)
            //    {
            //        ModulesListBox.Add(item);
            //    }

            ActivateItem((IScreen) viewModel);
        }

        //После выбора  модуля
        public void Handle(IScreen message)
        {
            ActivateItem(message);
        }
    }
}