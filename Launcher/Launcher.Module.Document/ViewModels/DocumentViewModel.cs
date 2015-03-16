using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core.HelperClass;
using MoonPdfLib;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(DocumentViewModel))]
    public class DocumentViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
       // private MoonPdfPanel _panel;
        private DocFile _message;
        private IWindowManager _windowsManager;

        [ImportingConstructor]
        public DocumentViewModel(DocFile message)
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _windowsManager = IoC.Get<IWindowManager>();

            _eventAggregator.Subscribe(this);
            _message = message;
        }

        public void PdfPanel()
        {
            _eventAggregator.PublishOnBackgroundThread(new FileNamePdfPanel(_message.Path));
            //Сделать так же

        }

        //public MoonPdfPanel PdfPanel2
        //{
        //    get { return _panel; }
        //    set
        //    {
        //        _panel = value;
        //        NotifyOfPropertyChange(() => PdfPanel2);
        //    }
        //}

        public void CloseWindow()
        {
            TryClose();
        }
    }
    public class FileNamePdfPanel
    {
        public FileNamePdfPanel(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}
