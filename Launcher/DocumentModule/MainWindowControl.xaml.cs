﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace DocumentModule
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MainWindowControl : UserControl
    {
        public static readonly string ResourcePath = System.IO.Path.GetFullPath(@"../../Resources");
        public static readonly string ModulesPath = System.IO.Path.GetFullPath(@"../../Modules");
        private SQLiteConnection _sqLiteConnectionDatabase;
        public MainWindowControl()
        {
            InitializeComponent();
            ConnectToDB(ResourcePath);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //kostyl из базы забирать категории
            foreach (string item in new List<string>(new[] { "ГОСТ", "ОСТ", "ТР", "Приказы", "Распоряжения" }))
            {
                var listBoxCategoryItem = new CategoryControl { TextBlockCategory = { Text = item } };
                ListBoxDocument.Items.Add(listBoxCategoryItem);
            }
        }

        private void ListBoxDocument_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SelectedItemGetText((CategoryControl)sender);
            var lb = ((ListBox)sender);
            var item = (CategoryControl)lb.SelectedValue;
            //MessageBox.Show(string.Format("Я {0}", item.TextBlockCategory.Text));
            Collection_Create();
        }

        public string SelectedItemGetText(CategoryControl categoryControl)
        {
            return categoryControl.TextBlockCategory.Text;
        }
        private void ConnectToDB(string path)
        {   
            _sqLiteConnectionDatabase = new SQLiteConnection(string.Format(@"Data Source={0}\Normative documents.db",path));
            _sqLiteConnectionDatabase.Open();
        }

        public void Collection_Create()
        {
            List<ListBoxItem> Coll = new List<ListBoxItem>();
            SQLiteCommand SqlCommand = new SQLiteCommand("Select NAME_GOST,Source_To_Document from GOST_TABLE", _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = SqlCommand.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    ListBoxItem a = new ListBoxItem();
                    a.Content = sqlReader["NAME_GOST"].ToString();
                    a.FontSize = 18;
                    a.Height = 40;
                    a.Tag = sqlReader["Source_To_Document"].ToString();
                    a.MouseLeftButtonDown += new MouseButtonEventHandler(a_MouseLeftButtonDown);
                    Docum.Items.Add(a);
                    
                }

            }
        }

       private void a_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

       private void Docum_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
           
           var lb = ((ListBox)sender);
           var item = (ListBoxItem)lb.SelectedValue;
           DocumentPresenter Dp = new DocumentPresenter();
           Dp.ShowDialog();
       }
    }
}
