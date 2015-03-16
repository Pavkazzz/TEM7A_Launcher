using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Caliburn.Micro;
using Launcher.Module.Document.ViewModels;
using MoonPdfLib;

namespace Launcher.Module.Document.Views
{
    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    /// 
    public partial class DocumentView : Window, IHandle<FileNamePdfPanel>
    {
        private IEventAggregator _eventAggregator;


        public DocumentView()
        {
            InitializeComponent();
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
        }

        public void Handle(FileNamePdfPanel message)
        {
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                var uc = new PDFViewer(message.FileName);
                this._windowsFormsHost.Child = uc;
                //this.PdfPanel.OpenFile(message.FileName);
                //this.PdfPanel.ViewType = ViewType.SinglePage;
                //this.PdfPanel.Zoom(2.0);
                ////this.PdfPanel.Touche
                //this.PdfPanel.PageRowDisplay = PageRowDisplayType.ContinuousPageRows;
            }));

        }
        //Начирикал тут в чём то подвох должен ьбыть ..
        //private void Window_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        //{
        //    e.ManipulationContainer = this;
        //    e.Handled = true;
        //}

        //private void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        //{
        //    MoonPdfPanel rectToMove = e.OriginalSource as MoonPdfPanel;
        //    Matrix rectsMatrix = ((MatrixTransform)rectToMove.RenderTransform).Matrix;
        //    rectsMatrix.ScaleAt(e.DeltaManipulation.Scale.X, e.DeltaManipulation.Scale.X, e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
        //    rectToMove.RenderTransform = new MatrixTransform(rectsMatrix);
        //    Rect containingRect = new Rect(((FrameworkElement)e.ManipulationContainer).RenderSize);
        //    Rect shapeBounds = rectToMove.RenderTransform.TransformBounds(new Rect(rectToMove.RenderSize));
        //    if (e.IsInertial && !containingRect.Contains(shapeBounds))
        //    {
        //        e.Complete();
        //    }
        //    e.Handled = true;

        //}

        //private void Window_InertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        //{
        //    e.TranslationBehavior.DesiredDeceleration = 10.0 * 96.0 / (1000.0 * 1000.0);

        //    // Decrease the velocity of the Rectangle's resizing by 
        //    // 0.1 inches per second every second.
        //    // (0.1 inches * 96 pixels per inch / (1000ms^2)
        //    e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96 / (1000.0 * 1000.0);

        //    // Decrease the velocity of the Rectangle's rotation rate by 
        //    // 2 rotations per second every second.
        //    // (2 * 360 degrees / (1000ms^2)
        //    e.RotationBehavior.DesiredDeceleration = 720 / (1000.0 * 1000.0);

        //    e.Handled = true;
        //}

        private void UIElement_OnManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = PdfPanel;
            e.Mode = ManipulationModes.All;
            throw new System.NotImplementedException();
        }

        private void UIElement_OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            UIElement element = (UIElement) e.Source;
            Matrix matrix = ((MatrixTransform) element.RenderTransform).Matrix;
            ManipulationDelta md = e.DeltaManipulation;
            throw new System.NotImplementedException();
        }
    }


}
