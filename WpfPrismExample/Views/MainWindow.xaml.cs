using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Prism.Ioc;
using Prism.Regions;
using WpfPrismExample.Constants;
using WpfPrismExample.Views.EventAggregator;
using WpfPrismExample.Views.Regions;

namespace WpfPrismExample.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary> 
  public partial class MainWindow : Window
  {
    /// <summary>
    /// All application views
    /// </summary>
    private readonly Dictionary<string, UserControl> _views;

    private readonly IRegionManager _regionManager;

    /// <summary>
    /// Get body region from MainWindow view
    /// </summary>
    private IRegion BodyRegion => _regionManager.Regions[RegionNames.BodyRegion];

    /// <summary>
    /// Get left region from MainWindow view
    /// </summary>
    private IRegion LeftRegion => _regionManager.Regions[RegionNames.LeftRegion];

    /// <summary>
    /// Get right region from MainWindow view
    /// </summary>
    private IRegion RightRegion => _regionManager.Regions[RegionNames.RightRegion];
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="container"></param>
    /// <param name="regionManager"></param>
    public MainWindow(IContainerExtension container, IRegionManager regionManager)
    {
      InitializeComponent();

      _regionManager = regionManager;

      _views = new Dictionary<string, UserControl>();
      // Use regions views
      _views.Add(nameof(BodyRegionView), container.Resolve<BodyRegionView>());
      _views.Add(nameof(CustomBodyRegionView), container.Resolve<CustomBodyRegionView>());
      // Use EventAggregator views
      _views.Add(nameof(PublisherView), container.Resolve<PublisherView>());
      _views.Add(nameof(SubscriberView), container.Resolve<SubscriberView>());

      Loaded += WindowLoaded;
    }

    /// <summary>
    /// Windows loaded event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
      // Add views into body region
      BodyRegion.Add(_views[nameof(BodyRegionView)]);
      BodyRegion.Add(_views[nameof(CustomBodyRegionView)]);
      BodyRegion.Add(_views[nameof(PublisherView)]);
      // Add views into right region
      RightRegion.Add(_views[nameof(SubscriberView)]);

      // deactivate all views in all regions
      DeactivateAllViews();

      // Activate view
      BodyRegion.Activate(_views[nameof(BodyRegionView)]);
    }

    /// <summary>
    /// Deactivate all views in region
    /// </summary>
    /// <param name="region"></param>
    private void DeactivateViews(IRegion region)
    {
      region.ActiveViews.ToList().ForEach(region.Deactivate);
    }

    /// <summary>
    /// Deactivate all views in all regions
    /// </summary>
    private void DeactivateAllViews()
    {
      DeactivateViews(BodyRegion);
      DeactivateViews(LeftRegion);
      DeactivateViews(RightRegion);
    }

    /// <summary>
    /// Activate BodyRegionView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActivateBodyRegionView_OnClick(object sender, RoutedEventArgs e)
    {
      DeactivateAllViews();
      BodyRegion.Activate(_views[nameof(BodyRegionView)]);
    }

    /// <summary>
    /// Activate CustomBodyRegionView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ActivateCustomBodyRegionView_OnClick(object sender, RoutedEventArgs e)
    {
      DeactivateAllViews();
      BodyRegion.Activate(_views[nameof(CustomBodyRegionView)]);
    }

    /// <summary>
    /// Show EventAggregator example
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void UsingEventAggregator_OnClick(object sender, RoutedEventArgs e)
    {
      DeactivateAllViews();

      BodyRegion.Activate(_views[nameof(PublisherView)]);
      RightRegion.Activate(_views[nameof(SubscriberView)]);
    }
  }
}
