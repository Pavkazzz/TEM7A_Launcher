using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{
    [Export(typeof(LauncherViewModel))]
    public class LauncherViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        /// <summary>
        /// ssssasdasd
        /// </summary>
 
        private readonly IEnumerable<ISearch> _search;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, [ImportMany(typeof(IModuleName))] IEnumerable<IModuleName> aboutModule, MainModel model)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            _model = model;

            _eventAggregator.Subscribe(this);

            foreach (var moduleName in aboutModule.OrderBy(s => s.PositionNumber))
            {
                if (moduleName != null)
                {
                    model.Modules.Add(new ModuleItem(moduleName));
                }   
            }

            ListBoxModules = _model.Modules;
        }

        public void OpenModule()
        {
            //foreach (var name in IoC.GetAll<IModule>().Where(name => name.GetType() == (o as ModuleItem).ViewModel))
            //{
            //    _eventAggregator.PublishOnBackgroundThread(name);
            //}
            var qwe = "qweqweqwe";
            //MessageBox.Show("AXAXAX");
        }

        public void OpenModule(ModuleItem o)
        {
            //if (o != null)
            //{
                foreach (var name in IoC.GetAll<IModule>().Where(name => name.GetType() == o.ViewModel))
                {
                    //TODO Dialog window
                    //::SEM
                    _eventAggregator.PublishOnBackgroundThread(name);
                }
            //}
            //else
            //{
            //    MessageBox.Show("Модуль не пришёл");
            //}
        }

        public void OpenFlyout()
        {

            var flyout = this._flyouts[0];
            flyout.IsOpen = !flyout.IsOpen;
        }

        #region Search

        private readonly IObservableCollection<FlyoutBaseViewModel> _flyouts = new BindableCollection<FlyoutBaseViewModel>();

        public IObservableCollection<FlyoutBaseViewModel> Flyouts
        {
            get
            {
                return this._flyouts;
            }
        }

        public void Search()
        {
            _eventAggregator.PublishOnBackgroundThread(IoC.Get<FlyoutSearchViewModel>());
            //History
        }

        public void Search(string text)
        {
            
        } 
        #endregion

        #region Property
        private IWindowManager _windowManager;
        private MainModel _model;
        private BindableCollection<ModuleItem> _myModules;
        //private BindableCollection<Color> _color; 
        private ModuleItem _selectedModule;

        public BindableCollection<ModuleItem> ListBoxModules
        {
            get { return _myModules; }
            set
            {
                _myModules = value;
                NotifyOfPropertyChange(() => ListBoxModules);
            }
        }

        //public BindableCollection<ModuleItem> Colors
        //{
        //    get { return _color; }
        //    set
        //    {
        //        _color = value;
        //        NotifyOfPropertyChange(()=>ListBoxModules);
        //    }
        //} 

        public ModuleItem SelectedListBoxModules
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                NotifyOfPropertyChange(() => ListBoxModules);
            }
        }

        

        
        #endregion

        #region Handle

        //После выбора модулей
        //public void Handle(IModule viewModel)
        //{
        //    //TODO список модулей

            

        //    ActivateItem((IScreen)viewModel);
        //}

        //public void Handle(IScreen message)
        //{
        //    ActivateItem(message);
        //} 
        #endregion


        protected override void OnInitialize()
        {
            base.OnInitialize();
            this.DisplayName = "Caliburn.Metro.Demo";
            this._flyouts.Add(IoC.Get<FlyoutSearchViewModel>());
        }
        }


}