using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher.ViewModels
{

    [Export(typeof(LauncherViewModel))]
    class LauncherViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<IScreen>
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public LauncherViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            ActivateItem(IoC.Get<ModuleListViewModel>());

            //var qwe = _aboutModule.Name;
            //Modules.Add(new Module { Name = _aboutModule.Name, Description = _aboutModule.Description});
        }

        public override sealed void ActivateItem(IScreen item)
        {
            base.ActivateItem(item);
        }

        //public void Test()
        //{
        //    ActivateItem(ModuleList.ToList()[1].Value as IScreen);
        //}

        public void Handle(IScreen viewModel)
        {
            ActivateItem(viewModel);
            //var model = IoC.Get<Model>();
            //if (model.Auth)
            //{
            //    ActivateItem(IoC.Get<AppViewModel>());
            //}
        }

    }
}
