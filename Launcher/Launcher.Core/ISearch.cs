using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Launcher.Core
{
    public interface ISearch
    {
        List<string> DoSearch(string name);
    }
}