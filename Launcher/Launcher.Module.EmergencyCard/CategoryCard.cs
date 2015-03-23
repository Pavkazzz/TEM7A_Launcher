using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Module.EmergencyCard
{
   public class CategoryCard
   {
       public string CategoryName { get; private set; }


       public CategoryCard()
       {
           
       }

       public CategoryCard(string Category_name)
       {
           CategoryName = Category_name;
       }
    }
}
