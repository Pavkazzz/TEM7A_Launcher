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
                var listBoxCategoryItem = new CategoryControl();
                listBoxCategoryItem.TextBlockCategory.Text = item;
                ListBoxDocument.Items.Add(listBoxCategoryItem);
            }
        }

    }
}
