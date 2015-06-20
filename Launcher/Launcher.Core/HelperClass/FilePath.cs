using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Core.HelperClass
{
    static public class FilePath
    {
        public static string GetFilePath(string path, string pathname)
        {
            return Path.GetFullPath(Path.Combine(@"..\..\..\..\File", path, pathname));
        }
    }
}
