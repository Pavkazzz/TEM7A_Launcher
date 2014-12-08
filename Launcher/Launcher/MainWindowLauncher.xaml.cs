﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var asm = Assembly.LoadFile(App.ModulesPath + @"\WpfControlLibrary1.dll");
            var tlist = asm.GetTypes();
            var myControl = (from t in tlist where t.Name == "UserControl1" select Activator.CreateInstance(t) as UserControl).FirstOrDefault();
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
    }
}
