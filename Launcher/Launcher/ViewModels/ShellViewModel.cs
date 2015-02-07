using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Launcher.ViewModels
{
    [Export(typeof (IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell, IHandle<LoginViewModel>, IHandle<UpdaterViewModel>
    {
        private readonly IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            
            ActivateItem(IoC.Get<UpdaterViewModel>());
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

        public void Handle(LoginViewModel message)
        {
            ActivateItem(IoC.Get<LauncherViewModel>());
        }

        public void Handle(UpdaterViewModel message)
        {
            ActivateItem(IoC.Get<LoginViewModel>());
        }
    }
}