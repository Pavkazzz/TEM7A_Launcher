using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Launcher.ViewModel
{
    [Export(typeof (IShell))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            ActivateItem(IoC.Get<UpdaterViewModel>());
        }

        public void Handle(string message)
        {
            var model = IoC.Get<Model>();
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