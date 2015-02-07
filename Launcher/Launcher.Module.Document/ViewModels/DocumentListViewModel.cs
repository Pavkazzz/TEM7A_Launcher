using System.ComponentModel.Composition;
using Caliburn.Micro;

[Export(typeof(DocumentListViewModel))]
public class DocumentListViewModel : Screen
{
    private IEventAggregator _eventAggregator;

    [ImportingConstructor]
    public DocumentListViewModel(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
    }
}