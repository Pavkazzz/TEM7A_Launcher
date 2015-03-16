using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Caliburn.Micro;
using Launcher.Module.Document.ViewModels;
using MoonPdfLib;

namespace Launcher.Module.Document.Views
{
    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    /// 
    public partial class DocumentView : Window, IHandle<FileNamePdfPanel>
    {
        private IEventAggregator _eventAggregator;


        public DocumentView()
        {
            InitializeComponent();
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
        }

        public void Handle(FileNamePdfPanel message)
        {
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                var uc = new PDFViewer(message.FileName);
                this.PdfPanel.Child = uc;
            }));
        }
    }
}
