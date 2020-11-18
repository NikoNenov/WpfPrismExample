using System;
using System.Windows;
using Prism.Commands;
using WpfPrismExample.Core;
using WpfPrismExample.Utilities;

namespace WpfPrismExample.ViewModels.Regions
{
  public class CustomBodyRegionViewModel : BaseViewModel
  {
    private string _updateText;

    private IApplicationCommands _applicationCommands;

    public IApplicationCommands ApplicationCommands
    {
      get => _applicationCommands;
      set => SetProperty(ref _applicationCommands, value);
    }

    public string UpdateText
    {
      get => _updateText; 
      set => SetProperty(ref _updateText, value); 
    }

    /// <summary>
    /// Update display time command
    /// </summary>
    public DelegateCommand UpdateDisplayTimeCommand { get; }

    /// <summary>
    /// Custom save command
    /// </summary>
    public DelegateCommand CustomSaveCommand { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public CustomBodyRegionViewModel(IApplicationCommands applicationCommands)
    {
      AppLogger.Log.Trace("");
      _applicationCommands = applicationCommands;

      UpdateText = $"Updated: {DateTime.Now}";
      UpdateDisplayTimeCommand = new DelegateCommand(ExecuteUpdateDisplayTime);

      // composite commands
      CustomSaveCommand = new DelegateCommand(ExecuteCustomSave);
      _applicationCommands.SaveCommand.RegisterCommand(CustomSaveCommand);
    }

    /// <summary>
    /// Execute update display time action
    /// </summary>
    private void ExecuteUpdateDisplayTime()
    {
      AppLogger.Log.Trace("");

      UpdateText = $"Updated: {DateTime.Now}";
    }

    /// <summary>
    /// Execute custom save action
    /// </summary>
    private void ExecuteCustomSave()
    {
      MessageBox.Show("Custom save");
    }
  }
}
