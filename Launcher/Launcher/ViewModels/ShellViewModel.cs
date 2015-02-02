using System.ComponentModel.Composition;
using Caliburn.Micro;

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
            ActivateItem(IoC.Get<UpdaterViewModel>());
        }

        public void Handle(string message)
        {
            if (message == "UpdateSuccess")
            {
                ActivateItem(IoC.Get<LoginViewModel>());
            }

            if (message == "LoginSuccess")
            {
                ActivateItem(IoC.Get<LauncherViewModel>());
            }
            //var model = IoC.Get<Model>();
            //if (model.Auth)
            //{
            //    ActivateItem(IoC.Get<AppViewModel>());
            //}
        }

        public override sealed void ActivateItem(IScreen item)
        {
            base.ActivateItem(item);
        }
    }
}