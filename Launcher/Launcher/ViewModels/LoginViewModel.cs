using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{
    [Export(typeof (LoginViewModel))]
    public class LoginViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly User _user;

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PersonalNumber { get; set; }
        public string Password { get; set; }

        [ImportingConstructor]
        public LoginViewModel(IEventAggregator eventAggregator, User user)
        {
            _eventAggregator = eventAggregator;
            _user = user;
        }

        public void Login()
        {



            //TODO Login
            if (_user.Login("admin", "admin"))
            {
                _eventAggregator.PublishOnBackgroundThread(this);
            }
        }
    }
}