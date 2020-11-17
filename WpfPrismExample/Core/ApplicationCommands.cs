using Prism.Commands;

namespace WpfPrismExample.Core
{
  public class ApplicationCommands : IApplicationCommands
  {
    private CompositeCommand _saveCommand = new CompositeCommand();

    /// <summary>
    /// Save command implementation
    /// </summary>
    public CompositeCommand SaveCommand => _saveCommand;
  }
}
