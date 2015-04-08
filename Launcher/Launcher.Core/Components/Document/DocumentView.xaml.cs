using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Caliburn.Micro;
using CefSharp;
using CefSharp.WinForms;
using Launcher.Core.HelperClass;

namespace Launcher.Core.Components.Document
{
    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    /// 
    public partial class DocumentView : Window//, IHandle<FileNamePdfPanel>
    {
        private IEventAggregator _eventAggregator;

        public DocumentView()
        {
            InitializeComponent();
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
        }

        public DocumentView(FileNamePdfPanel message)
        {
            InitializeComponent();
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);

            Debug.WriteLine(message.FileName);

            Console.WriteLine(message.FileName);

            var uc = new ChromiumWebBrowser(message.FileName)
            {
                Dock = DockStyle.Fill,
                BrowserSettings = new BrowserSettings()
            };

            this.PdfBrowser.Child = uc;
        }

        private void Close(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
