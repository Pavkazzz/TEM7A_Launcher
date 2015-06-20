﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Xps.Packaging;
using Caliburn.Micro;
using CefSharp;
using Launcher.Core.HelperClass;
using Microsoft.Office.Interop.Word;
using NLog;
using LogManager = NLog.LogManager;
using Window = System.Windows.Window;

namespace Launcher.Core.Components.Document
{
    public class OpenDocument
    {
        private IWindowManager _windowManager;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private Window _window;

        public void DialogDocument(DocFile doc, string databasePath)
        {
            var time = Stopwatch.StartNew();
            _logger.Trace(string.Format("{0}, {1}, {2}", doc.Path, doc.Name, databasePath));

            var ext = Path.GetExtension(doc.Path);

            _logger.Trace(ext);

            Console.WriteLine(ext);
            
            if (ext == ".pdf")
            {
                if (databasePath != "")
                {
                    var db = new DataBase(Path.GetFullPath(databasePath));

                    var index = db.SqlSelect("Select id from History order by id desc", new List<string> { "id" });

                    if (index.Count > 0)
                    {
                        db.SqlInsert(
                            string.Format(
                                "INSERT INTO \"main\".\"History\" (\"DocumentName\",\"DocumentIndex\",\"Path\") VALUES ('{0}','{1}','{2}')",
                                doc.Name, index[0]["id"], doc.Path));
                    }
                    else
                    {
                        db.SqlInsert(
                            string.Format(
                                "INSERT INTO \"main\".\"History\" (\"DocumentName\",\"DocumentIndex\",\"Path\") VALUES ('{0}','{1}','{2}')",
                                doc.Name, '1', doc.Path));
                    }
                }
                

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
                 _window = new DocumentView().ShowPdf(new FileNameDoc(doc.Path));
                
                _logger.Trace(time.Elapsed);

            }

            if (ext == ".doc" || ext == ".docx")
            {
                string xpsDocument = string.Empty;
                Console.WriteLine(ext);
                string convertedXpsDoc = Path.ChangeExtension(doc.Path, ".xps");
                Console.WriteLine(convertedXpsDoc);
                if (!File.Exists(convertedXpsDoc))
                {

                    xpsDocument = ConvertWordToXps(doc.Path, convertedXpsDoc);
                }
                else
                {
                    xpsDocument = convertedXpsDoc;
                }
                
                _window = new DocumentView().ShowXps(new FileNameDoc(xpsDocument));

            }

            if (ext == ".xps")
            {
                _window = new DocumentView().ShowXps(new FileNameDoc(doc.Path));
            }

            _window.ShowDialog(); 
        }

        private static string ConvertWordToXps(string wordFilename, string xpsFilename)
        {
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            try
            {
                wordApp.Documents.Open(wordFilename);

                // To Invisible the word document
                wordApp.Application.Visible = false;

                // Minimize the opened word document
                wordApp.WindowState = WdWindowState.wdWindowStateMinimize;

                var doc = wordApp.ActiveDocument;

                //TODO много одинаковых
                doc.SaveAs(xpsFilename, WdSaveFormat.wdFormatXPS);

                return xpsFilename;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs, The error message is  " + ex.ToString());
                return null;
            }
            finally
            {
                //  wordApp.Documents.Close();
                ((_Application)wordApp).Quit(WdSaveOptions.wdDoNotSaveChanges);
            }
        }
    }
}