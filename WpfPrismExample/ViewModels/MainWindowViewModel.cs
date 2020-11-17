using System.Windows;
using Prism.Commands;
using Prism.Regions;
using WpfPrismExample.Constants;
using WpfPrismExample.Core;
using WpfPrismExample.Views.Regions;

namespace WpfPrismExample.ViewModels
{
  public class MainWindowViewModel : BaseViewModel
  {
    private readonly IRegionManager _regionManager;
    private IApplicationCommands _applicationCommands;
    
    public IApplicationCommands ApplicationCommands
    {
      get => _applicationCommands;
      set => SetProperty(ref _applicationCommands, value);
    }

    /// <summary>
    /// Show BodyRegionView command
    /// </summary>
    public DelegateCommand ShowBodyRegionViewCommand { get; }
    
    /// <summary>
    /// Show CustomBodyRegionView command
    /// </summary>
    public DelegateCommand ShowCustomBodyRegionViewCommand { get; }

    public DelegateCommand SaveCommand { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="regionManager"></param>
    /// <param name="applicationCommands"></param>
    public MainWindowViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands)
    {
      _applicationCommands = applicationCommands;
      _regionManager = regionManager;

      // commands
      ShowBodyRegionViewCommand = new DelegateCommand(ShowBodyRegionViewAction);
      ShowCustomBodyRegionViewCommand = new DelegateCommand(ShowCustomBodyRegionViewAction);

      // composite commands
      SaveCommand = new DelegateCommand(SaveAction);
      _applicationCommands.SaveCommand.RegisterCommand(SaveCommand);
    }

    /// <summary>
    /// Command action
    /// </summary>
    private void ShowBodyRegionViewAction()
    {
      _regionManager.RequestNavigate(RegionNames.BodyRegion, nameof(BodyRegionView));
    }

    /// <summary>
    /// Command action
    /// </summary>
    private void ShowCustomBodyRegionViewAction()
    {
      _regionManager.RequestNavigate(RegionNames.BodyRegion, nameof(CustomBodyRegionView));
    }

    /// <summary>
    /// Save action 
    /// </summary>
    private void SaveAction()
    {
      MessageBox.Show("Main save", "Main save");
    }
  }
}
