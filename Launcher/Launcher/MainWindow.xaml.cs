using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using MahApps.Metro.Controls;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly string _resourcePath = System.IO.Path.GetFullPath(@"../../Resources");
        MainWindowLauncher WindowLauncher = new MainWindowLauncher();
        private SQLiteConnection SQLiteConnectionDatabase;
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

        private bool Login(String login, String pass)
        {
            bool result = false;
            try
            {
                var sqlSelect = new SQLiteCommand(string.Format("Select Name, Lastname from Accounts where Login = '{0}' and Password = '{1}'", login, pass),
                    SQLiteConnectionDatabase);
                SQLiteDataReader sqlReader = sqlSelect.ExecuteReader();
                result = sqlReader.HasRows;
                sqlReader.Close();
                
               
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            return result;
        }

        private void Registration(User user)
        {
            try
            {
                var sqlSelect = new SQLiteCommand(string.Format("Insert Into Accounts Values ('{0}', '{1}', '{2}', '{3}', '{4}')", user.Login,
                    user.Password, user.Name, user.Lastname, user.Email), SQLiteConnectionDatabase);
                SQLiteDataReader sqlReader = sqlSelect.ExecuteReader();
                sqlReader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void Accept_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Passwb1.Password == Passwb2.Password)
            {
                User user = new User(Login_tbx.Text, Passwb1.Password, Name_tbx.Text, Family_tbx.Text, email_tbx.Text);
                Registration(user);   
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login(EntryLogin.Text, EntryPassword.Password))
            {
               // MessageBox.Show("Успешно");
                WindowLauncher.ShowDialog();
            }
            else
            {
                MessageBox.Show("Запись не найдена");
            }
        }
    }
}
