namespace Launcher.Core.HelperClass
{
    public class DocFile
    {
        public DocFile(string name)
        {
            Name = name;
            Path = string.Empty;
        }

        public DocFile(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public string Name { get; set; }
        public string Path { get; private set; }
    }
}