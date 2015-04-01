namespace Launcher.Module.Document.ViewModels
{
    public class FileNamePdfPanel
    {
        public FileNamePdfPanel(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}