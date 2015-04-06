using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Windows.Threading;
using Caliburn.Micro;
using CefSharp;
using Launcher.Core.HelperClass;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(DocumentViewModel))]
    public class DocumentViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private DocFile _message;
        private IWindowManager _windowsManager;

        [ImportingConstructor]
        public DocumentViewModel(DocFile message)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            _eventAggregator = IoC.Get<IEventAggregator>();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Start();

            _windowsManager = IoC.Get<IWindowManager>();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            stopwatch.Start();
            _eventAggregator.Subscribe(this);
            _message = message;
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Start();
            if (!Cef.IsInitialized)
            {


                var settings = new CefSharp.CefSettings
                {
                    CachePath = "C:/Temp/cache",
                };
                settings.CefCommandLineArgs.Add("disable-gpu", "disable-gpu");
                settings.BrowserSubprocessPath = @"CefSharp.BrowserSubprocess.exe";
                //settings.UserAgent = "CefSharp Browser" + Cef.CefSharpVersion; // Example User Agent
                //settings.CefCommandLineArgs.Add("renderer-process-limit", "1");
                //settings.CefCommandLineArgs.Add("renderer-startup-dialog", "renderer-startup-dialog");
                //settings.CefCommandLineArgs.Add("disable-gpu-vsync", "");
                //settings.CefCommandLineArgs.Add("enable-media-stream", "1"); //Enable WebRTC
                //settings.CefCommandLineArgs.Add("no-proxy-server", "1"); //Don't use a proxy server, always make direct connections. Overrides any other proxy server flags that are passed.

                //Disables the DirectWrite font rendering system on windows.
                //Possibly useful when experiencing blury fonts.
                //settings.CefCommandLineArgs.Add("disable-direct-write", "");

                settings.LogSeverity = LogSeverity.Disable;

                if (!Cef.Initialize(settings))
                {
                    throw new Exception("Unable to Initialize Cef");
                }
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            
        }

        public void PdfBrowser()
        {

            _eventAggregator.PublishOnBackgroundThread(new FileNamePdfPanel(_message.Path));
            
            //Сделать так же
        }

        public void CloseWindow()
        {
            //Cef.Shutdown();
            TryClose();
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
