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
        private string _password = string.Empty;
        private string _personalid = string.Empty;
        private bool _remember;


        #region PropertyForView
        public string PersonalNumber
        {
            get { return _personalid; }
            set
            {
                _personalid = value;
                NotifyOfPropertyChange(() => PersonalNumber);
            }
        }
        public string Password
        {
            get { return _personalid; }
            set
            {
                _personalid = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public bool RememberMe
        {
            get { return _remember; }
            set
            {
                _remember = value;
                NotifyOfPropertyChange(() => RememberMe);
            }
        }

        #endregion

        [ImportingConstructor]
        public LoginViewModel(IEventAggregator eventAggregator, User user)
        {
            _eventAggregator = eventAggregator;
            _user = user;
        }

        public void Login()
        {
            //TODO Login
            if (_user.Login(PersonalNumber, Password, RememberMe))
            {
                _eventAggregator.PublishOnBackgroundThread(IoC.Get<LauncherViewModel>());
            }
            //TODO регистрация если нет такого
            //else
            //{
            //    _eventAggregator.PublishOnBackgroundThread(IoC.Get<RegistrationViewModel>());
            //}
        }

        public void Register()
        {
            _eventAggregator.PublishOnBackgroundThread(IoC.Get<RegistrationViewModel>());
        }
    }
}