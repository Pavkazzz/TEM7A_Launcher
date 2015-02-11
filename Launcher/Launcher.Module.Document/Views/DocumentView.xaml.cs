using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
                this.PdfPanel.OpenFile(message.FileName);
                this.PdfPanel.ViewType = ViewType.SinglePage;
                this.PdfPanel.Zoom(2.0);
                this.PdfPanel.PageRowDisplay = PageRowDisplayType.ContinuousPageRows;
            }));

        }
    }


}
