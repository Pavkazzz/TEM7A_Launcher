using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MahApps.Metro.Controls;

namespace Launcher.ViewModels
{
    public class FlyoutBaseViewModel : PropertyChangedBase
    {
        private string header;

        private bool isOpen;

        private Position position;

        private float _flyoutWidth;

        public float FlyoutWidth
        {
            get
            {
                return this._flyoutWidth;
            }

            set
            {
                if (value == this._flyoutWidth)
                {
                    return;
                }

                this._flyoutWidth = value;
                this.NotifyOfPropertyChange(() => this.FlyoutWidth);
            }
        }

        public string Header
        {
            get
            {
                return this.header;
            }

            set
            {
                if (value == this.header)
                {
                    return;
                }

                this.header = value;
                this.NotifyOfPropertyChange(() => this.Header);
            }
        }

        public bool IsOpen
        {
            get
            {
                return this.isOpen;
            }

            set
            {
                if (value.Equals(this.isOpen))
                {
                    return;
                }

                this.isOpen = value;
                this.NotifyOfPropertyChange(() => this.IsOpen);
            }
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value == this.position)
                {
                    return;
                }

                this.position = value;
                this.NotifyOfPropertyChange(() => this.Position);
            }
        }
    }
}
