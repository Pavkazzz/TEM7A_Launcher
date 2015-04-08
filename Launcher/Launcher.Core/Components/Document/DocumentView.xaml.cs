﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
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
    public partial class DocumentView : Window//, IHandle<FileName>
    {
        private IEventAggregator _eventAggregator;

        public DocumentView()
        {
            InitializeComponent();
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
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

        private void Close(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
