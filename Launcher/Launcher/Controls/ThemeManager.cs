using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher.Controls
{
    [Export(typeof(IThemeManager))]
    public class ThemeManager : IThemeManager
    {
        private readonly ResourceDictionary themeResources;

        public ThemeManager()
        {
            //TODO
            this.themeResources = new ResourceDictionary();
            //{
            //    Source =
            //        new Uri("pack://application:,,,/Launcher/Resources/Theme1.xaml")
            //};
        }

        public ResourceDictionary GetThemeResources()
        {
            return this.themeResources;
        }
    }
}
