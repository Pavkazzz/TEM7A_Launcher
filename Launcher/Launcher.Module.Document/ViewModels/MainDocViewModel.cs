using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using Caliburn.Micro;
using Launcher.Core;

namespace Launcher.Module.Document.ViewModels
{
    [Export(typeof (IModule))]
    public sealed class MainDocViewModel : Conductor<IScreen>.Collection.OneActive, IModule
    {
        private IEventAggregator _eventAggregator;

        public BindableCollection<Category> CategoryList;
        
        [ImportingConstructor]
        public MainDocViewModel(IEventAggregator eventAggregator)
        {
            CategoryList = new BindableCollection<Category>();
            CategoryList.Add(new Category(@"ГОСТ"));

            _eventAggregator = eventAggregator;
            ActivateItem(IoC.Get<HistoryViewModel>());
        }
    }

    public class Category
    {
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}