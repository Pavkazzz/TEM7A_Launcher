using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;

namespace Launcher.Module.Document.Views
{
    /// <summary>
    ///     Interaction logic for MainDocView.xaml
    /// </summary>
    [Export(typeof (MainDocView))]
    public partial class MainDocView : Window
    {
        public MainDocView()
        {
            InitializeComponent();
        }
    }
}