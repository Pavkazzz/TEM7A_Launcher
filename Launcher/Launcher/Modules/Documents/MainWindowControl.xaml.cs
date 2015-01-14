using System.Windows;
using System.Windows.Controls;
using Launcher;
using Launcher.Modules.Documents;
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
            var doc = new ControlTextListBoxWrap
            {
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Bottom
            };

            doc.SelectionChanged += Docum_SelectionChanged;
            doc.AlternationCount = 2;
            foreach (var item in DatabaseDoc.GetCategory(name))
            {
                
                ListBoxItem a = new ListBoxItem();
                a.Content = item;
                //a.TextAlignment = TextAlignment.Justify;
                a.HorizontalAlignment = HorizontalAlignment.Stretch;
                a.VerticalAlignment = VerticalAlignment.Center;
                // a.TextWrapping = TextWrapping.Wrap;
                a.FontSize = 18;
                a.Height = 70;
                a.Width = 1300;
                //TODO WIDTH
                //a.Width = Width;
                
                a.Tag = Path.Combine(App.DocPath, Correct(item) + ".pdf");
                doc.Items.Add(a);
            }
            GridDocument.Children.Add(doc);
        }

        private static string Correct(string item)
        {
            return item.Replace('\r', ' ').Replace('\n', ' ').Replace('\"', ' ').Replace('"', ' ');
        }

       private void Docum_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
            var lb = ((ControlTextListBoxWrap)sender);
            Pdf.ShowPdf(((ListBoxItem)lb.SelectedItem).Tag.ToString(), 0);
         
       }


    }
}
