using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{
    [Export(typeof (IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell, IHandle<LauncherViewModel>, IHandle<RegistrationViewModel>
    {
        private readonly IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            
            ActivateItem(IoC.Get<LoginViewModel>());
        }
        //public void Handle(string message)
        //{
        //    //var model = IoC.Get<Model>();
        //    //if (model.Auth)
        //    //{
        //    //    ActivateItem(IoC.Get<AppViewModel>());
        //    //}
        //}

        public override sealed void ActivateItem(IScreen item)
        {
            base.ActivateItem(item);
        }

        public void Handle(LauncherViewModel message)
        {
            ActivateItem(IoC.Get<LauncherViewModel>());
        }

        public void Handle(RegistrationViewModel message)
        {
            ActivateItem(IoC.Get<RegistrationViewModel>());
        }
    }
}