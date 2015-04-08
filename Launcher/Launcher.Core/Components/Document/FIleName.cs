namespace Launcher.Core.Components.Document
{
    //TODO использовать DocFile
    public class FileNameDoc
    {
        public FileNameDoc(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}