using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.Document.ViewModels
{
    public class MainDocViewModel : Screen, IModule
    {
        private IEventAggregator _eventAggregator;



        public override string DisplayName
        {
            get { return "Модуль документ"; }
        }

        [ImportingConstructor]
        public MainDocViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }


    }
}
