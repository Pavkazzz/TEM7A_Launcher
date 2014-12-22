using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace DocumentModule
{
    /// <summary>
    /// Логика взаимодействия для DocumentPresenter.xaml
    /// </summary>
    public partial class DocumentPresenter : Window
    {
        public DocumentPresenter()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Expander_OnExpanded(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
