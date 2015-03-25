using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Caliburn.Micro;
using System.IO;
using System.Runtime.Caching;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Launcher.Module.Document.ViewModels;

namespace Launcher.Module.Document.Views
{
    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    /// 
    public partial class DocumentView : Window, IHandle<FileNamePdfPanel>
    {
        private IEventAggregator _eventAggregator;

        private static readonly bool DebuggingSubProcess = Debugger.IsAttached;

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
                Debug.WriteLine(message.FileName);

                Console.WriteLine(message.FileName);
                

                var uc = new ChromiumWebBrowser(message.FileName)
                {
                    Dock = DockStyle.Fill,
                };
                
                uc.BrowserSettings = new BrowserSettings();


                this.PdfBrowser.Child = uc;
            }));
        }
    }

}
