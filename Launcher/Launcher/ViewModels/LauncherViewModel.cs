using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{
    [Export(typeof (LauncherViewModel))]
    internal class LauncherViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<IModule>, IHandle<IScreen>
    {
        private readonly IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            ModulesListBox = new BindableCollection<ModuleItem>();

            ActivateItem(IoC.Get<ModuleListViewModel>());
        }

        public BindableCollection<ModuleItem> ModulesListBox { get; set; }
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