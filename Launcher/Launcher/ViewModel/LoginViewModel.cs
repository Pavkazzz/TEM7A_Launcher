using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher
{
    [Export(typeof(LoginViewModel))]
    class LoginViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private User _user;

        [ImportingConstructor]
        public LoginViewModel(IEventAggregator eventAggregator, User user)
        {
            _eventAggregator = eventAggregator;
            _user = user;
        }

        public void Login()
        {
            if (_user.Login("admin", "admin"))
            {
                _eventAggregator.PublishOnBackgroundThread("LoginSuccess");    
            }
        }
    }
}