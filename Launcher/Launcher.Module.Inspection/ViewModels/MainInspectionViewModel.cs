using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Module.Inspection.Views;

namespace Launcher.Module.Inspection.ViewModels
{
    [Export(typeof(IModule))]
    class MainInspectionViewModel: Conductor<IScreen>.Collection.OneActive, IModule
    {
        private IEventAggregator _eventAggregator;
        private object _noticeContentControl;

        [ImportingConstructor]
        public MainInspectionViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Notice()
        {
            //NoticeContentControl = IoC.Get<NoticeViewModel>();
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

    }
}
