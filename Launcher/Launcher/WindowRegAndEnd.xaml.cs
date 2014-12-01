using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Diagnostics;

namespace Launcher
{
    /// <summary>
    /// Логика взаимодействия для WindowRegAndEnd.xaml
    /// </summary>
    public partial class WindowRegAndEnd : MetroWindow
    {
        public WindowRegAndEnd()
        {
            InitializeComponent();
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            //Process.Start(path + "\\system32\\osk.exe");
        }
    }
}
