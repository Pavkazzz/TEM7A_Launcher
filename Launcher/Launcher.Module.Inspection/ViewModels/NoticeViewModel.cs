using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Launcher.Module.Inspection.ViewModels
{
    [Export(typeof (NoticeViewModel))]
    internal class NoticeViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private object _noticeContentControl;

        [ImportingConstructor]
        public NoticeViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }
}