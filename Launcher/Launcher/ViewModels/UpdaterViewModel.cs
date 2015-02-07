using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Launcher.ViewModels
{
    [Export(typeof (UpdaterViewModel))]
    public class UpdaterViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public UpdaterViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Start()
        {
            _eventAggregator.PublishOnBackgroundThread(this);
        }
    }
}