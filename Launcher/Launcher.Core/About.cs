using System;

namespace Launcher.Core
{
    public class About
    {
        public string AboutName { get; set; }

        public About()
        {
            AboutName = String.Empty;
        }

        public About(string aboutName)
        {
            AboutName = aboutName;
        }
    }
}