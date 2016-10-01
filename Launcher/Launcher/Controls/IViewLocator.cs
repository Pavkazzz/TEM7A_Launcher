using System;
using System.Windows;

namespace Launcher.Controls
{
    public interface IViewLocator
    {
        UIElement GetOrCreateViewType(Type viewType);
    }
}
