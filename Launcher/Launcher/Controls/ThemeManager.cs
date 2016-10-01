using System.ComponentModel.Composition;
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
            themeResources = new ResourceDictionary();
            //{
            //    Source =
            //        new Uri("pack://application:,,,/Launcher/Resources/Theme1.xaml")
            //};
        }

        public ResourceDictionary GetThemeResources()
        {
            return themeResources;
        }
    }
}
