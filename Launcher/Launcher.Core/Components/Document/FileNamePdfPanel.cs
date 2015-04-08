namespace Launcher.Core.Components.Document
{
    //TODO использовать DocFile
    public class FileNamePdfPanel
    {
        public FileNamePdfPanel(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}