using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Launcher.Module.EmergencyCard.Views
{
    /// <summary>
    ///     Interaction logic for MainEmergencyCardView.xaml
    /// </summary>
    [Export(typeof (MainEmergencyCardView))]
    public partial class MainEmergencyCardView : UserControl
    {
        public MainEmergencyCardView()
        {
            InitializeComponent();
        }
    }
}