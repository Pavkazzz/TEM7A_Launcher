using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.ViewModels
{
    [Export(typeof(RegistrationViewModel))]
    public class RegistrationViewModel : Screen
    {
        #region PropertyForView

        private string _personalid = string.Empty;
        private string _passwordRepeat = string.Empty;
        private string _password = string.Empty;
        private string _name = string.Empty;
        private string _lastname = string.Empty;

        public string Name {
            get { return _name; }
            set { _name = value; NotifyOfPropertyChange(() => Name); }
        }

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; NotifyOfPropertyChange(() => LastName); }
        }
        public string Patronymic 
        {
            get { return _patronymic; }
            set { _patronymic = value; NotifyOfPropertyChange(() => Patronymic); }
        }

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
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public string PasswordRepeat
        {
            get { return _passwordRepeat; }
            set
            {
                _passwordRepeat = value;
                NotifyOfPropertyChange(() => PasswordRepeat);
            }
        }


        #endregion

        private User _user;
        private IEventAggregator _eventAggregator;
        private string _patronymic;

        [ImportingConstructor]
        public RegistrationViewModel(IEventAggregator eventAggregator, User user)
        {
            _eventAggregator = eventAggregator;
            _user = user;
        }

        public void Register()
        {
            if (Password == PasswordRepeat)
            {
                _user.Name = Name;
                _user.Lastname = LastName;
                _user.Patronymic = Patronymic;
                _user.PersonalNumber = PersonalNumber;
                //TODO хранить сразу хэши
                _user.Password = Password;
                _user.Registration(_user);
            }

            _eventAggregator.PublishOnBackgroundThread("LoginViewModel");
        }
    }
}
