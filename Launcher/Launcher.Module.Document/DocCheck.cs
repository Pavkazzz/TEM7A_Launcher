using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher.Core;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

namespace Launcher.Module.Document
{
    class DocCheck
    {
        public static bool DocumentCheck()
        {
            var db = new DataBase(new DocAbout().DbPath);
            //TODO Check File.Exists Document table


            //Chech Search
            //TODO Parallel
            var dbDocSearch = db.SqlSelect(@"Select * from Search", new List<string>(){"id"});

            var dbDocument = db.SqlSelect(@"Select * from Document
                                            ", new List<string>() {"id"});

            var dbDocCategory = db.SqlSelect(@"Select Path from Category", new List<string>() {"Path"});

            //TODO if
            if (dbDocSearch.Count == 0)//== dbDocument.Count)
            {
                foreach (var dbpath in dbDocCategory)
                {
                    var hz = dbpath["Path"];
                    if (hz != string.Empty && hz != "\n")
                    {
                        var path = Path.GetFullPath(Path.Combine(@"..\..\..\..\File", dbpath["Path"]));
                        string[] files = Directory.GetFiles(path, "*.pdf", SearchOption.AllDirectories);
                        foreach (var file in files)
                        {
                            var text = ParsePdfUsingPdfBox(file).ToLower(new CultureInfo("ru-RU"));
                            var fileName = Path.GetFileName(file);
                            var dbIndexOfSearch = db.SqlSelect(string.Format(@"select id, PathName from Document where PathName == '{0}'", fileName), new List<string>(){"id"});
                            if (dbIndexOfSearch.Count > 0)
                            {
                                var index = dbIndexOfSearch[0]["id"];
                                db.SqlInsert(string.Format("Insert Into Search (Document_id, SearchText) Values ('{0}', '{1}')", index, text));    
                            }
                        } 
                    }
                }
            }
            return true;

        }

        private static string ParsePdfUsingPdfBox(string file)
        {
            PDDocument doc = null;
            try
            {
                doc = PDDocument.load(file);
                PDFTextStripper stripper = new PDFTextStripper();
                var text = stripper.getText(doc);
                return text.Replace(System.Environment.NewLine, "");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + file);
                return "";
            }
            finally
            {
                if (doc != null)
                {
                    doc.close();
                }
            }
        }
    }
}
