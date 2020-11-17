using System;
using System.Windows;
using Prism.Commands;
using WpfPrismExample.Core;
using WpfPrismExample.Utilities;

namespace WpfPrismExample.ViewModels
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
    /// Button F command
    /// </summary>
    public DelegateCommand ButtonFCommand { get; }

    /// <summary>
    /// Save main command
    /// </summary>
    public DelegateCommand CustomSaveCommand { get; private set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    public CustomBodyRegionViewModel(IApplicationCommands applicationCommands)
    {
      AppLogger.Log.Trace("");
      _applicationCommands = applicationCommands;

      UpdateText = $"Updated: {DateTime.Now}";
      ButtonFCommand = new DelegateCommand(ExecuteButtonF);

      // composite commands
      CustomSaveCommand = new DelegateCommand(CustomSaveAction);
      _applicationCommands.SaveCommand.RegisterCommand(CustomSaveCommand);
    }

    /// <summary>
    /// Execute button F action
    /// </summary>
    private void ExecuteButtonF()
    {
      AppLogger.Log.Trace("");

      UpdateText = $"Updated: {DateTime.Now}";
    }

    /// <summary>
    /// Save main action
    /// </summary>
    private void CustomSaveAction()
    {
      MessageBox.Show("Custom save", "Custom save");
    }
  }
}
