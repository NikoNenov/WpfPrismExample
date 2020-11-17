using Prism.Commands;

namespace WpfPrismExample.Core
{
  public interface IApplicationCommands
  {
    CompositeCommand SaveCommand { get; }
  }
}
