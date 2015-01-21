using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Launcher.ViewModel
{
    [Export(typeof(LoginViewModel))]
    class LoginViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public LoginViewModel(IEventAggregator eventAggregator, Model model)
        {
            _eventAggregator = eventAggregator;
        }

        public void Login()
        {
            _eventAggregator.PublishOnBackgroundThread("LoginSuccess");
        }
    }
}