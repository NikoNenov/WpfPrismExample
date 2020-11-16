using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using WpfPrismExample.Constants;
using WpfPrismExample.Views;
using WpfPrismExample.Views.Region;

namespace WpfPrismExample.ViewModels
{
  public class MainWindowViewModel : BindableBase
  {
    private string _title = "Prism examples";
    private readonly IRegionManager _regionManager;

    /// <summary>
    /// Show BodyRegionView command
    /// </summary>
    public DelegateCommand ShowBodyRegionViewCommand { get; }
    
    /// <summary>
    /// Show CustomBodyRegionView command
    /// </summary>
    public DelegateCommand ShowCustomBodyRegionViewCommand { get; }
    
    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }

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
