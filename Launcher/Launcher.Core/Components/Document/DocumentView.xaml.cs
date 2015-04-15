using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Xps.Packaging;
using Caliburn.Micro;
using CefSharp;
using CefSharp.WinForms;
using Launcher.Core.HelperClass;
using NLog;
using LogManager = NLog.LogManager;

namespace Launcher.Core.Components.Document
{
    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    /// 
    public partial class DocumentView : Window
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private IEventAggregator _eventAggregator;

        public DocumentView()
        {
            var time = Stopwatch.StartNew();
            InitializeComponent();
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
            _logger.Trace(time.Elapsed);
        }

        public Window ShowPdf(FileNameDoc message)
        {
            Debug.WriteLine(message.FileName);

            Console.WriteLine(message.FileName);

            
            var host = new WindowsFormsHost();

            var uc = new ChromiumWebBrowser(message.FileName)
            {
                Dock = DockStyle.Fill,
                BrowserSettings = new BrowserSettings()
            };

            host.Child = uc;

            GridViewer.Children.Add(host);

            return this;
        }

        public Window ShowXps(FileNameDoc message)
        {
            Console.WriteLine(message.FileName);

            
            XpsDocument xpsDoc = new XpsDocument(message.FileName, FileAccess.Read);

            var detalViewer = new DocumentViewer();
            detalViewer.Document = xpsDoc.GetFixedDocumentSequence();
            GridViewer.Children.Add(detalViewer);

            return this;
        }


        private void Close(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
