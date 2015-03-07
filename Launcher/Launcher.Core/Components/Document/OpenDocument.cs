using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core.HelperClass;

namespace Launcher.Core.Components.Document
{
    public class OpenDocument
    {
        private IWindowManager _windowManager;

        public void ShowPdf(DocFile doc, string DatabasePath)
        {
            //view для документа.
            if (doc != null)
            {
                var db = new Launcher.Core.DataBase(Path.GetFullPath(DatabasePath));

                var index = db.SqlSelect("Select id from History order by id desc", new List<string>() { "id" });

                if (index.Count > 0)
                {
                    db.SqlInsert(string.Format("INSERT INTO \"main\".\"History\" (\"DocumentName\",\"DocumentIndex\",\"Path\") VALUES ('{0}','{1}','{2}')", doc.Name, index[0]["id"], doc.Path));
                }
                else
                {
                    db.SqlInsert(string.Format("INSERT INTO \"main\".\"History\" (\"DocumentName\",\"DocumentIndex\",\"Path\") VALUES ('{0}','{1}','{2}')", doc.Name, '1', doc.Path));
                }
                _windowManager = IoC.Get<IWindowManager>();
                _windowManager.ShowDialog(new DocumentViewModel(doc));
            }
        }

    }
}
