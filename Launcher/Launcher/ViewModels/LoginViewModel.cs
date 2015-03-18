using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using Caliburn.Micro;
using Launcher.Core;
using MahApps.Metro.Controls;
using Xceed.Wpf.DataGrid.Converters;
using MahApps.Metro.Controls.Dialogs;
using Xceed.Wpf.Toolkit;

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
            get { return _password; }
            set
            {
                _password = value;
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
                _eventAggregator.PublishOnBackgroundThread("LauncherViewModel");
            }
            //TODO регистрация если нет такого
            else
            {
                
                MessageBox.Show("Неверный Логин/Пароль. \nПроверьте правильность вводимых данных","Ошибка Авторизации");
            }
            //else
            //{
            //    _eventAggregator.PublishOnBackgroundThread(IoC.Get<RegistrationViewModel>());
            //}
        }

        public void Register()
        {
            _eventAggregator.PublishOnBackgroundThread("RegistrationViewModel");
        }
    }
}