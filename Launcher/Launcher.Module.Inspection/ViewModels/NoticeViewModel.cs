using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Launcher.Module.Inspection.ViewModels
{
    [Export(typeof(NoticeViewModel))]
    class NoticeViewModel : Screen
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
