using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.Inspection.ViewModels
{
    [Export(typeof (IModule))]
    internal class MainInspectionViewModel : Conductor<IScreen>.Collection.OneActive, IModule
    {
        private IEventAggregator _eventAggregator;
        private object _noticeContentControl;

        [ImportingConstructor]
        public MainInspectionViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public object NoticeContentControl
        {
            get { return _noticeContentControl; }
            set
            {
                _noticeContentControl = value;
                NotifyOfPropertyChange(() => NoticeContentControl);
            }
        }

        public void Notice()
        {
            //NoticeContentControl = IoC.Get<NoticeViewModel>();
        }
    }
}