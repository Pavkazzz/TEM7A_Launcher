using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.ViewModels;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(DocumentListViewModel))]
    public class DocumentListViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private IWindowManager _windowManager;

        [ImportingConstructor]
        public DocumentListViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
        }

        public void ShowDoc()
        {
            //view для документа.
            //_windowManager.ShowDialog(IoC.Get<DocumentViewModel>());
        }
    }
}