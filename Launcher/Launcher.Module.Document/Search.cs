using System.Collections.Generic;
using Launcher.Core;

namespace Launcher.Module.Document
{
    class Search : ISearch
    {
        public string ModuleName
        {
            get { return new DocAbout().Name; }
        }

        public List<string> DoSearch(string name)
        {
            name = name.ToLower();
            var result = new List<string>();
            var db = new DataBase(new DocAbout().DbPath);

            //TODO Search Hisory
            if (name == "")
            {
                
            }
            else
            {
                var dbSelect = db.SqlSelect(string.Format(@"Select Name from Search 
                                                            Left join Document
                                                            on Document.id == Search.Document_id
                                                            where SearchText like '%{0}%' ", name),
                    new List<string> { "Name" });

                foreach (var searchResult in dbSelect)
                {
                    result.Add(searchResult["Name"]);
                }
            }


            
            return result;
        }
    }
}
