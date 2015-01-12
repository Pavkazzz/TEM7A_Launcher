using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Launcher.Modules.Documents
{
    public class Helper
    {
        public class Category
        {
            public string Name { get; private set; }
            public string TableName { get; private set;}

            public Category(string name, string tableName)
            {
                Name = name;
                TableName = tableName;
            }
        }
    }
}
