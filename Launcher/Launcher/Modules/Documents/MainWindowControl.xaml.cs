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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using Launcher;
using Launcher.Modules.Documents;
using MoonPdfLib;
using Path = System.IO.Path;

namespace DocumentModule
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MainWindowControl : UserControl
    {


        public MainWindowControl()
        {
            InitializeComponent();
            GridDocument.Children.Add(new HistoryControl());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //kostyl из базы забирать категории
            foreach (var item in DatabaseDoc.CategoryList())
            {
                var listBoxCategoryItem = new CategoryControl { TextBlockCategory = { Text = item.Name}, Name = item.TableName };
                ListBoxDocument.Items.Add(listBoxCategoryItem);
            }
        }

        private void ListBoxDocument_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var lb = ((ListBox)sender);
            var item = (CategoryControl)lb.SelectedValue;

            Collection_Create(item.Name);
        }

        private void Collection_Create(string name)
        {
            GridDocument.Children.Clear();
            var doc = new ListBox();
            doc.SelectionChanged += Docum_SelectionChanged;
            doc.AlternationCount = 2;
            foreach (var item in DatabaseDoc.GetCategory(name))
            {
                ListBoxItem a = new ListBoxItem();
                a.Content = item;
                a.FontSize = 18;
                a.Height = 50;
                //TODO WIDTH
                a.Width = Width;
                
                a.Tag = Path.Combine(App.DocPath, item.Replace('\r', ' ').Replace('\n', ' ').Replace('\"', ' ').Replace('"', ' ') + ".pdf");
                doc.Items.Add(a);
        }
            GridDocument.Children.Add(doc);
        }

       private void Docum_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
           var lb = ((ListBox)sender);
           Pdf.ShowPdf(((ListBoxItem)lb.SelectedItem).Tag.ToString(), 0);
        }


    }
}
