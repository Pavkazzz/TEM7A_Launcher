using System;
using System.Collections.Generic;
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
        static public void ShowPdf(string path)
        {
            var dp = new DocumentPresenter();
            var pdf = new MoonPdfPanel();
            pdf.OpenFile(path);
            DatabaseDoc.AddToHistory(path);
            pdf.ViewType = ViewType.SinglePage;
            pdf.Zoom(2.0);
            pdf.PageRowDisplay = PageRowDisplayType.ContinuousPageRows;
            dp.GridDocument.Children.Add(pdf);
            dp.ShowDialog();
            GeneratePageThumb(path);
        }

        static public void GeneratePageThumb(string path)
        {
            GhostscriptWrapper.GeneratePageThumb(path, string.Format("{0}.jpg", path), 1, 500, 500, 500, 300);
        }
    }
}
