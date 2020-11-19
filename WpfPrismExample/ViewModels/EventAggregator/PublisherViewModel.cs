using Prism.Commands;
using Prism.Events;
using WpfPrismExample.Core.Events;
using WpfPrismExample.Utilities;

namespace WpfPrismExample.ViewModels.EventAggregator
{
  public class PublisherViewModel : BaseViewModel
  {
    private readonly IEventAggregator _eventAggregator;

    private string _message;

    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public DelegateCommand SendMessageCommand { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="eventAggregator"></param>
    public PublisherViewModel(IEventAggregator eventAggregator)
    {
      _eventAggregator = eventAggregator;
      _message = "Message to Send";
      
      SendMessageCommand = new DelegateCommand(SendMessage);
    }

    /// <summary>
    /// Send message
    /// </summary>
    private void SendMessage()
    {
      AppLogger.Log.Trace($"Send message: {_message}");
      _eventAggregator.GetEvent<MessageSentEvent>().Publish(new MessageSentEventArgs{Message = _message});
    }
  }
}
