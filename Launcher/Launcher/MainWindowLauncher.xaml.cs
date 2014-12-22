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
using DocumentModule;
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
            //Модули
            ListBoxModules.Tag = Width - 150;
            var dataBase = new DataBase();
            foreach (var item in dataBase.SelectModulesList(App.ResourcePath))
            {
                item.Width = Width;
                ListBoxModules.Items.Add(item);
            }
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new MainWindowControl());
        }

        private void ListBoxModules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lb = (ListBox) sender;
            foreach (ListBoxItemModuleControl item in lb.Items)
            {

                item.ListBoxModuleControlMainGrid.Background = new SolidColorBrush(Colors.Gray);
                item.TextBlockTitle.Foreground = new SolidColorBrush(Colors.White);
            }
            ((ListBoxItemModuleControl) lb.Items[lb.SelectedIndex]).ListBoxModuleControlMainGrid.Background =
                new SolidColorBrush(Colors.White);
            ((ListBoxItemModuleControl) lb.Items[lb.SelectedIndex]).TextBlockTitle.Foreground =
                new SolidColorBrush(Colors.Black);
        }
    }
}
