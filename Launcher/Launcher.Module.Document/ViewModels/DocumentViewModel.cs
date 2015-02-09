using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(DocumentViewModel))]
    class DocumentViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public DocumentViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
        }
    }
}
