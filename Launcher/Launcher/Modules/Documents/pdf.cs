using System;
using System.IO;
using DocumentModule;
using MoonPdfLib;

namespace Launcher.Modules.Documents
{
    class Pdf
    {
        static public void ShowPdf(string path, int page)
        {
            var dp = new DocumentPresenter();
            var pdf = new MoonPdfPanel();
            if (File.Exists(path)) pdf.OpenFile(path);
            else
            {
                Console.WriteLine(@"Файл не найден:" + path);
                return;
            }

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
            
        }
    }
}
