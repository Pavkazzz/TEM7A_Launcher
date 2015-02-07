using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(HistoryViewModel))]
    public class HistoryViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public HistoryViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }
}