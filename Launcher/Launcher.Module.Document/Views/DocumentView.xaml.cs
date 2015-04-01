using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Runtime.Caching;
using System.Windows.Forms;
using Caliburn.Micro;
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
