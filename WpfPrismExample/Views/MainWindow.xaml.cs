using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Prism.Ioc;
using Prism.Regions;
using WpfPrismExample.Constants;

namespace WpfPrismExample.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary> 
  public partial class MainWindow : Window
  {
    private readonly Dictionary<string, UserControl> _views;

    private readonly IContainerExtension _container;
    private readonly IRegionManager _regionManager;
    private IRegion _bodyRegion;

    public MainWindow(IContainerExtension container, IRegionManager regionManager)
    {
      InitializeComponent();

      _container = container;
      _regionManager = regionManager;

      _views = new Dictionary<string, UserControl>();
      _views.Add(nameof(BodyRegionView), _container.Resolve<BodyRegionView>());
      _views.Add(nameof(CustomBodyRegionView), _container.Resolve<CustomBodyRegionView>());

      Loaded += WindowLoaded;
    }

    /// <summary>
    /// Windows loaded event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
      // Set body region from view
      _bodyRegion = _regionManager.Regions[RegionNames.BodyRegion];
      
      // Add views into region
      _bodyRegion.Add(_views[nameof(BodyRegionView)]);
      _bodyRegion.Add(_views[nameof(CustomBodyRegionView)]);
      
      // Activate view
      _bodyRegion.Activate(_views[nameof(BodyRegionView)]);
    }

    /// <summary>
    /// Activate BodyRegionView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActivateBodyRegionView_OnClick(object sender, RoutedEventArgs e)
    {
      _bodyRegion.Activate(_views[nameof(BodyRegionView)]);
    }

    /// <summary>
    /// Activate CustomBodyRegionView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActivateCustomBodyRegionView_OnClick(object sender, RoutedEventArgs e)
    {
      _bodyRegion.Activate(_views[nameof(CustomBodyRegionView)]);
    }
  }
}
