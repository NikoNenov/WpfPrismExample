using System.Collections.ObjectModel;
using Prism.Events;
using WpfPrismExample.Core.Events;
using WpfPrismExample.Utilities;

namespace WpfPrismExample.ViewModels.EventAggregator
{
  public class SubscriberViewModel : BaseViewModel
  {
    private readonly IEventAggregator _eventAggregator;
    private SubscriptionToken _subscriptionToken;

    private ObservableCollection<string> _messages;
    private bool _canFilter;
    private string _filter;

    public ObservableCollection<string> Messages
    {
      get => _messages;
      set => SetProperty(ref _messages, value);
    }
    
    public bool CanFilter
    {
      get => _canFilter;
      set
      {
        InitializeSubscriber(value);
        SetProperty(ref _canFilter, value);
      }
    }
    
    public string Filter
    {
      get => _filter;
      set
      {
        InitializeSubscriber(_canFilter);
        SetProperty(ref _filter, value);
      }
    }

    /// <summary>
    /// Constructor 
    /// </summary>
    /// <param name="eventAggregator"></param>
    public SubscriberViewModel(IEventAggregator eventAggregator)
    {
      Messages = new ObservableCollection<string>();

      _eventAggregator = eventAggregator;

      // Default subscriber initialize without filter
      InitializeSubscriber(false);
    }

    /// <summary>
    /// Initialize subscriber with or without a filter
    /// </summary>
    /// <param name="canFilter"></param>
    private void InitializeSubscriber(bool canFilter)
    {
      AppLogger.Log.Trace($"SubscriptionToken: {_subscriptionToken}, CanFilter: {canFilter}");

      if(_eventAggregator != null)
      {
        _subscriptionToken?.Dispose();

        if (canFilter)
        {
          _subscriptionToken = _eventAggregator.GetEvent<MessageSentEvent>().Subscribe(MessageReceived, ThreadOption.PublisherThread, false, (eventArgs) => eventArgs.Message.Contains(Filter));
        }
        else
        {
          _subscriptionToken = _eventAggregator.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
        }
      }
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
