﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{
    [Export(typeof(LauncherViewModel))]
    public class LauncherViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<IModule>, IHandle<IScreen>
    {
        private IEventAggregator _eventAggregator;

         
        private readonly IEnumerable<ISearch> _search;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, [ImportMany(typeof(IModuleName))] IEnumerable<IModuleName> aboutModule, MainModel model)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            _model = model;

            _eventAggregator.Subscribe(this);

            foreach (var moduleName in aboutModule)
            {
                if (moduleName != null)
                model.Modules.Add(new ModuleItem(moduleName));
            }

            

            ActivateItem(IoC.Get<ModuleListViewModel>());
        }

        public void OpenModule(ModuleItem o)
        {
            foreach (var name in IoC.GetAll<IModule>().Where(name => name.GetType() == o.ViewModel))
            {
                _eventAggregator.PublishOnBackgroundThread(name);
            }
        }

        public void OpenFlyout()
        {

            var flyout = this.flyouts[0];
            flyout.IsOpen = !flyout.IsOpen;
        }

        #region Search

        private readonly IObservableCollection<FlyoutBaseViewModel> flyouts =
    new BindableCollection<FlyoutBaseViewModel>();

        public IObservableCollection<FlyoutBaseViewModel> Flyouts
        {
            get
            {
                return this.flyouts;
            }
        }


        

        public void Search()
        {
            _eventAggregator.PublishOnBackgroundThread(new FlyoutSearchViewModel());
            //History
        }

        public void Search(string text)
        {
            
        
        } 
        #endregion

        #region Property
        string _searchString;
        private IWindowManager _windowManager;
        private MainModel _model;
        private BindableCollection<ModuleItem> _myModules;
        private ModuleItem _selectedModule;

        public string TextBoxSearch
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                NotifyOfPropertyChange(() => TextBoxSearch);
            }
        }

        public BindableCollection<ModuleItem> ModulesListBox
        {
            get { return _myModules; }
            set
            {
                _myModules = value;
                NotifyOfPropertyChange(() => ModulesListBox);
            }
        }

        public ModuleItem SelectedModulesListBox
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                NotifyOfPropertyChange(() => ModulesListBox);
            }
        }

        
        #endregion

        #region Handle

        //После выбора модулей
        public void Handle(IModule viewModel)
        {
            //TODO список модулей

            ModulesListBox = _model.Modules;

            ActivateItem((IScreen)viewModel);
        }

        public void Handle(IScreen message)
        {
            ActivateItem(message);
        } 
        #endregion


        protected override void OnInitialize()
        {
            base.OnInitialize();
            this.DisplayName = "Caliburn.Metro.Demo";
            this.flyouts.Add(new FlyoutSearchViewModel());
        }
    }

    public class SearchName
    {
        public SearchName()
        {
            
        }

        public SearchName(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}