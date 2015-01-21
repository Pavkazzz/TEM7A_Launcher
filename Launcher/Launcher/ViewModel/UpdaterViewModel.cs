﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Launcher
{
    [Export(typeof (UpdaterViewModel))]
    class UpdaterViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public UpdaterViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Start()
        {
            _eventAggregator.PublishOnBackgroundThread("UpdateSuccess");
        }
    }
}