using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentModule;
using MoonPdfLib;
using GhostscriptSharp;

namespace Launcher.Modules.Documents
{
    class Pdf
    {
        static public void ShowPdf(string path, int page)
        {
            var dp = new DocumentPresenter();
            var pdf = new MoonPdfPanel();
            pdf.OpenFile(path);
            pdf.Tag = path;
            DatabaseDoc.AddToHistory(path);
            pdf.GotoPage(page);
            pdf.ViewType = ViewType.SinglePage;
            pdf.Zoom(2.0);
            pdf.PageRowDisplay = PageRowDisplayType.ContinuousPageRows;
            dp.GridDocument.Children.Add(pdf);
            dp.ShowDialog();
            //if (!File.Exists(string.Format("{0}.jpg", path))) GeneratePageThumb(path);
        }
        
        static public void GeneratePageThumb(string path)
        {
            //GhostscriptWrapper.GeneratePageThumb(path, string.Format("{0}.jpg", path), 1, 750, 750, 1000, 1000);
        }
    }
}
