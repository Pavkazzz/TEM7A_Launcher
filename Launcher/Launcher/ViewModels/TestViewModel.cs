using Caliburn.Micro;

namespace Launcher.ViewModels
{
    public class TestViewModel : Screen, IShell
    {
        private readonly IObservableCollection<FlyoutBaseViewModel> flyouts =
            new BindableCollection<FlyoutBaseViewModel>();

        public IObservableCollection<FlyoutBaseViewModel> Flyouts
        {
            get
            {
                return flyouts;
            }
        }


        public void ToggleFlyout(int index)
        {
            var flyout = flyouts[index];
            flyout.IsOpen = !flyout.IsOpen;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            DisplayName = "Caliburn.Metro.Demo";
            flyouts.Add(IoC.Get<FlyoutSearchViewModel>());
        }
    }
}
