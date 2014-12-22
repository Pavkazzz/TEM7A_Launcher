using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Modules.Documents
{
    class Book
    {
        public string Name { get; private set; }
        public int Page { get; private set; }
        

        public Book()
        {
            
        }

        public Book(string name, int page)
        {
            Name = name;
            Page = page;
        }
    }
}
