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

        private void Collection_Create()
        {
            var bd = new DatabaseDoc();
            foreach (var item in bd.ReturnGost())
            {
                ListBoxItem a = new ListBoxItem();
                a.Content = item;
                a.FontSize = 18;
                a.Height = 40;
                a.Tag = Path.Combine(App.DocPath, item + ".pdf");
                Docum.Items.Add(a);
            }
        }

        public string SelectedItemGetText(CategoryControl categoryControl)
        {
            return categoryControl.TextBlockCategory.Text;
        }

       private void Docum_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
           
           var lb = ((ListBox)sender);
           var item = (ListBoxItem)lb.SelectedValue;

           DocumentPresenter Dp = new DocumentPresenter();
           var pdf = new MoonPdfPanel();
           pdf.OpenFile(((ListBoxItem) lb.SelectedItem).Tag.ToString());
           pdf.ViewType = ViewType.SinglePage;
           pdf.PageRowDisplay = PageRowDisplayType.ContinuousPageRows;
           Dp.GridDocument.Children.Add(pdf);
           Dp.ShowDialog();
        }
    }
}
