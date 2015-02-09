using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MoonPdfLib;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(DocumentViewModel))]
    class DocumentViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private MoonPdfPanel _panel;

        [ImportingConstructor]
        public DocumentViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, DocFile message)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            var pdf = new MoonPdfPanel();
            if (File.Exists(message.Path))
            {
                pdf.OpenFile(message.Path);
                PdfPanel = pdf;
            }
            
        }


        public MoonPdfPanel PdfPanel
        {
            get { return _panel; }
            set
            {
                _panel = value;
                NotifyOfPropertyChange(() => PdfPanel);
            } 
        }
    }
}
