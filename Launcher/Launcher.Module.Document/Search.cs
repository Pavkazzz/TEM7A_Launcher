using System.Collections.Generic;
using System.IO;
using Launcher.Core;
using Launcher.Core.HelperClass;

namespace Launcher.Module.Document
{
    class Search : ISearch
    {
        public string ModuleName
        {
            get { return new DocAbout().Name; }
        }

        public List<DocFile> DoSearch(string name)
        {
            name = name.ToLower();
            var result = new List<DocFile>();
            var db = new DataBase(new DocAbout().DbPath);

            //TODO Search Hisory
            if (name == "")
            {
                
            }
            else
            {
                var dbSelect = db.SqlSelect(string.Format(@"Select Document.Name,Category.Path, Document.PathName from Search 
                                                            Left join Document on Document.id == Search.Document_id
                                                            Left join Category on Category.id == Document.Category
                                                            where SearchText like '%{0}%' ", name),
                    new List<string> { "Name", "Path", "PathName" });

                foreach (var searchResult in dbSelect)
                {
                    result.Add(new DocFile(searchResult["Name"], FilePath.GetFilePath(searchResult["Path"], searchResult["PathName"])));
                }
            }


            
            return result;
        }
    }
}
