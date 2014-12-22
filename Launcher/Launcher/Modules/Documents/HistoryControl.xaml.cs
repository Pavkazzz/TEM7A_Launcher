using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Launcher.Modules.Documents;
using MahApps.Metro.Controls;
using System.Drawing;
using MahApps.Metro;

namespace DocumentModule
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class HistoryControl : UserControl
    {
        public HistoryControl()
        {
            InitializeComponent();

             

        }

        private void GridHistory_Loaded(object sender, RoutedEventArgs e)
        {
            var count = 0;
            foreach (var item in DatabaseDoc.GetHistory())
            {
                var sp = new Tile();
                
                sp.HorizontalContentAlignment = HorizontalAlignment.Center;
                sp.VerticalContentAlignment = VerticalAlignment.Center;
               // sp.Content = item;
                sp.Click += sp_Click;
                sp.TiltFactor = 1;
                if (File.Exists(string.Format("{0}.jpg", item.Name)))
                {
                    //sp.Background = new ImageBrush(new BitmapImage(new Uri(string.Format("{0}.jpg", item))));
                }
                sp.Tag = item.Page;
                sp.Title = item.Name;
                sp.Width = GridHistory.ActualWidth/3;
                sp.Height = GridHistory.ActualHeight/3;
                Grid.SetRow(sp, count / 3);
                Grid.SetColumn(sp, count % 3);
                GridHistory.Children.Add(sp);
                count += 1;
                
            }
        }

        void sp_Click(object sender, RoutedEventArgs e)
        {
            Pdf.ShowPdf(((Tile) sender).Title, (int)((Tile)sender).Tag);
        }
    }
}
