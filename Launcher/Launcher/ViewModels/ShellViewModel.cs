using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using Caliburn.Micro;
using Launcher.Core;
using NLog;
using LogManager = NLog.LogManager;

namespace Launcher.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell, IHandle<string>, IHandle<FlyoutBaseViewModel>, IHandle<IModule>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;

            _eventAggregator.Subscribe(this);

            DisplayName = "ИС Помошник машиниста";

            CheckModules();

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        private void CheckModules()
        {
            foreach (var check in IoC.GetAll<IModuleName>())
            {
                try
                {
                    check.PrimaryCheck();
                }
                catch (NotImplementedException e)
                {
                    
                }
            }
        }

        public void OnClose()
        {
            Process.GetCurrentProcess().Kill();
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
                return flyouts;
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
                flyouts.Insert(0, message);
            }
            var flyout = Flyouts[0];
            flyout.IsOpen = !flyout.IsOpen;
        }

        public void Handle(IModule message)
        {
            var time = Stopwatch.StartNew();

            ActivateItem((IScreen) message);

            _logger.Trace(time.Elapsed);
        }
    }
}