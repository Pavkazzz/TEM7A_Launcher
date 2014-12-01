using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SQLiteConnection SQLiteConnectionDatabase;
        private readonly string _resourcePath = System.IO.Path.GetFullPath(@"../../Resources");
        private SQLiteDataAdapter _sqLiteDataAdapter;

        public MainWindow()
        {
            InitializeComponent();
            LoadDB();
        }

        private void LoadDB()
        {
            try
            {

                SQLiteConnectionDatabase = new SQLiteConnection(string.Format(@"Data Source={0}\db.db", _resourcePath));
                SQLiteConnectionDatabase.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
