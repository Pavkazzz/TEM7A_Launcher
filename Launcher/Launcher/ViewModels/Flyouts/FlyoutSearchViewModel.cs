using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;

namespace Launcher.ViewModels
{
    class FlyoutSearchViewModel : FlyoutBaseViewModel
    {
        public FlyoutSearchViewModel()
        {
            this.Header = "Search";
            this.Position = Position.Top;
            this.FlyoutWidth = 600;
        }
    }
}
