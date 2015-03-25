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
            var set = new CefSettings();
            set.CefCommandLineArgs.Add("disable-gpu", "1");
            set.CefCommandLineArgs.Add("disable-gpu-vsync", "1");
            Cef.Initialize(set);

            var uc = new ChromiumWebBrowser(message.FileName)
            {
                Dock = DockStyle.Fill,
            };
            uc.BrowserSettings = new BrowserSettings();

            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                //this.PdfPanel.Child = uc;
                //PdfBrowser.NavigateToString(string.Format(@"<HTML><IFRAME SCROLLING=""YES"" SRC=""{0}""></IFRAME></HTML>", message.FileName));
                //PdfBrowser.Navigate(new System.Uri(message.FileName));
                Debug.WriteLine(message.FileName);

                Console.WriteLine(message.FileName);

                //PdfBrowser.Load(message.FileName);

                this.PdfBrowser.Child = uc;
            }));
        }
    }
}
