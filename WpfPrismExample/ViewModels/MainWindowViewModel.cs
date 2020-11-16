using Prism.Commands;
using Prism.Regions;
using WpfPrismExample.Constants;
using WpfPrismExample.Views;

namespace WpfPrismExample.ViewModels
{
  public class MainWindowViewModel : BaseViewModel
  {
    private readonly IRegionManager _regionManager;

    /// <summary>
    /// Show BodyRegionView command
    /// </summary>
    public DelegateCommand ShowBodyRegionViewCommand { get; }
    
    /// <summary>
    /// Show CustomBodyRegionView command
    /// </summary>
    public DelegateCommand ShowCustomBodyRegionViewCommand { get; }

    public MainWindowViewModel(IRegionManager regionManager)
    {
      _regionManager = regionManager;

      ShowBodyRegionViewCommand = new DelegateCommand(ShowBodyRegionViewAction);
      ShowCustomBodyRegionViewCommand = new DelegateCommand(ShowCustomBodyRegionViewAction);
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
  }
}
