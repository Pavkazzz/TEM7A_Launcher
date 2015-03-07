using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher.Core;

namespace Launcher.Module.Document
{
    class Search : ISearch
    {
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

                var DbSelect = db.SqlSelect(string.Format(@"    Select Name from Search 
                                                                Left join Document
                                                                on Document.id == Search.Document_id
                                                                where SearchText like '%{0}%'
                                                            ", name),
                    new List<string>() { "Name" });

                foreach (var searchResult in DbSelect)
                {
                    result.Add(searchResult["Name"]);
                }
            }


            
            return result;
        }
    }
}
