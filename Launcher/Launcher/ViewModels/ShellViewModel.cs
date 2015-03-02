using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell, IHandle<string>, IHandle<FlyoutBaseViewModel>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;

            _eventAggregator.Subscribe(this);

            DisplayName = "ИС Помошник машиниста";

            ActivateItem(IoC.Get<LoginViewModel>());
        }


        //TODO переделать на typeof вместо string
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
            switch (message)
            {
                case "LoginViewModel":
                    ActivateItem(IoC.Get<LoginViewModel>());
                    break;
  
                case "LauncherViewModel":
                    ActivateItem(IoC.Get<LauncherViewModel>());
                    break;
            
                case "RegistrationViewModel":
                    ActivateItem(IoC.Get<RegistrationViewModel>());
                    break;
            }
        }


        private readonly IObservableCollection<FlyoutBaseViewModel> flyouts =
    new BindableCollection<FlyoutBaseViewModel>();

        public IObservableCollection<FlyoutBaseViewModel> Flyouts
        {
            get
            {
                return this.flyouts;
            }
        }


        public void Open()
        {
            _eventAggregator.PublishOnBackgroundThread(IoC.Get<FlyoutSearchViewModel>());
        }

        public void Handle(FlyoutBaseViewModel message)
        {
            if (flyouts.Count(x => x.Header == message.Header) == 0)
            {
                this.flyouts.Insert(0, message);
            }
            var flyout = Flyouts[0];
            flyout.IsOpen = !flyout.IsOpen;
        }
    }
}