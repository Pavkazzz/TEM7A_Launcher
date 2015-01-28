﻿using System.ComponentModel.Composition;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof(IModule))]
    public class MainDocViewModel : Screen, IModule
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public MainDocViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }
}