using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
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