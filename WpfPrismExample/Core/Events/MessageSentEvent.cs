using Prism.Events;

namespace WpfPrismExample.Core.Events
{
  /// <summary>
  /// The real work of connecting publishers and subscribers is done by the PubSubEvent class.
  /// This is the only implementation of the EventBase class that is included in the Prism Library.
  /// This class maintains the list of subscribers and handles event dispatching to the subscribers.
  ///
  /// The PubSubEvent class is a generic class that requires the payload type to be defined as the generic type.This helps enforce,
  /// at compile time, that publishers and subscribers provide the correct methods for successful event connection.
  /// The following code shows a partial definition of the PubSubEvent class.
  ///
  /// See: https://prismlibrary.com/docs/event-aggregator.html
  /// </summary>
  public class MessageSentEvent : PubSubEvent<MessageSentEventArgs> { }
}
