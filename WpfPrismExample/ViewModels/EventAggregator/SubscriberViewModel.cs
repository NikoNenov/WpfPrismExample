using System.Collections.ObjectModel;
using Prism.Events;
using WpfPrismExample.Core.Events;

namespace WpfPrismExample.ViewModels.EventAggregator
{
  public class SubscriberViewModel : BaseViewModel
  {
    private ObservableCollection<string> _messages;

    public ObservableCollection<string> Messages
    {
      get => _messages;
      set => SetProperty(ref _messages, value);
    }

    /// <summary>
    /// Constructor 
    /// </summary>
    /// <param name="eventAggregator"></param>
    public SubscriberViewModel(IEventAggregator eventAggregator)
    {
      Messages = new ObservableCollection<string>();

      eventAggregator.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
    }

    /// <summary>
    /// Event message received
    /// </summary>
    /// <param name="eventArgs"></param>
    private void MessageReceived(MessageSentEventArgs eventArgs)
    {
      Messages.Add(eventArgs.Message);
    }
  }
}
