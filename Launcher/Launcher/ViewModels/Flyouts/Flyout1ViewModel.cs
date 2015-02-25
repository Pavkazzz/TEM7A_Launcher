using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;

namespace Launcher.ViewModels.Flyouts
{
    public class Flyout1ViewModel : FlyoutBaseViewModel
    {
        public Flyout1ViewModel()
        {
            this.Header = "settings";
            this.Position = Position.Right;
        }
    }
}
