using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;
using System.Xml;
using System.IO;
using System.Windows.Markup;

namespace Launcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindowLauncher.xaml 
    /// </summary>
    public partial class MainWindowLauncher : MetroWindow
    {
        public MainWindowLauncher()
        {
            InitializeComponent();
            StartTimer();
            TextBlockAny.Text = "Номер локомотива,\n номер поезда \n табельный номер";
            
           // ListBoxModules.Items.Add(myControl);
           // var sql = Assembly.LoadFile(App.ResourcePath + @"\LoginWindow.xaml");
           
        }

        private void StartTimer()
        {
            var dateTimer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            dateTimer.Tick += DateTimer_Tick;
            dateTimer.Start();
        }

        void DateTimer_Tick (object sender, EventArgs e)
        {
            DateTimeLabel.Content = DateTime.Now.ToLongDateString() + '\n' + DateTime.Now.ToLongTimeString();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //КАСТЫЛЁК УАХАХАХАХ
            ListBoxModules.Tag = Width - 150;
            var _dataBase = new DataBase();
            foreach (var item in _dataBase.SelectModulesList(App.ResourcePath))
            {
                item.Width = Width;
                ListBoxModules.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // XmlReader xr = XmlReader.Create(input: new StringReader("C:/Users/Cemko/Source/Repos/Launcher/Launcher/Launcher/LoginWindow.xaml"));
           // var control = XamlReader.Load(xr) as Grid;
          // CCAdd.TryFindResource()
            ContentGrid.Children.Add(new WindowTipo());
        }
        public static void CurrentWindow(UserControl window,string color)
        {
            //Window CurApp = Application.Current.MainWindow;
            //CurApp.Content = window;
            //((ContentControl))CurApp.FindName("transitionins")).Content = window;
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            ContentGrid.Children.Clear();

            var asm = Assembly.LoadFile(App.ModulesPath + @"\DocumentModule.dll");
            var tlist = asm.GetTypes();
            var myControl = (from t in tlist where t.Name == "MainWindowControl" select Activator.CreateInstance(t) as UserControl).FirstOrDefault();
            if (myControl != null) ContentGrid.Children.Add(myControl);
        }

        private void ListBoxModules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lb = (ListBox)sender;
            foreach (ListBoxItemModuleControl item in lb.Items)
            {
                item.ListBoxModuleControlMainGrid.Background = new SolidColorBrush(Colors.Gray);
            }
            ((ListBoxItemModuleControl) lb.Items[lb.SelectedIndex]).ListBoxModuleControlMainGrid.Background = new SolidColorBrush(Colors.White);
        }
    }
}
