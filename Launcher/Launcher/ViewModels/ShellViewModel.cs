using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{
    [Export(typeof (IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell, IHandle<string>
    {
        private readonly IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            DisplayName = "ИС Помошник машиниста";

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


        public void Handle(LauncherViewModel message)
        {

            ActivateItem(IoC.Get<LauncherViewModel>());
        }

        public void Handle(RegistrationViewModel message)
        {
            ActivateItem(IoC.Get<RegistrationViewModel>());
        }

        public void Handle(string message)
        {
            if (message == "LoginViewModel")
            {
                ActivateItem(IoC.Get<LoginViewModel>());
            }
            if (message == "LauncherViewModel")
            {
                ActivateItem(IoC.Get<LauncherViewModel>());
            }
            if (message == "RegistrationViewModel")
            {
                ActivateItem(IoC.Get<RegistrationViewModel>());
            }
        }
    }
}