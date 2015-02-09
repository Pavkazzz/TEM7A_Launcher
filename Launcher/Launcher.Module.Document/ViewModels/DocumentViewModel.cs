using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Launcher.Module.Document.Views;
using MoonPdfLib;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(DocumentViewModel))]
    public class DocumentViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private MoonPdfPanel _panel;
        private DocFile _message;

        [ImportingConstructor]
        public DocumentViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, DocFile message)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _message = message;

        }

        public void PdfPanel()
        {
            _eventAggregator.PublishOnBackgroundThread(new FileNamePdfPanel(_message.Path));
        }

        public MoonPdfPanel PdfPanel2
        {
            get { return _panel; }
            set
            {
                _panel = value;
                NotifyOfPropertyChange(() => PdfPanel2);
            } 
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
