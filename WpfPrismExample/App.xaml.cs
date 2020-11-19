using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using WpfPrismExample.Core;
using WpfPrismExample.Utilities;
using WpfPrismExample.Views;
using WpfPrismExample.ViewModels;
using WpfPrismExample.ViewModels.EventAggregator;
using WpfPrismExample.ViewModels.Regions;
using WpfPrismExample.Views.EventAggregator;
using WpfPrismExample.Views.Regions;

namespace WpfPrismExample
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
    /// <summary>
    /// The CreateShell method allows a developer to specify the top-level window for a Prism application.
    /// The shell is usually the MainWindow or MainPage.
    /// Implement this method by returning an instance of your application's shell class.
    /// In a Prism application, you can create the shell object, or resolve it from the container, depending on your application's requirements.
    /// </summary>
    /// <returns></returns>
    protected override Window CreateShell()
    {
      AppLogger.Log.Trace("");
      return Container.Resolve<MainWindow>();
    }

    /// <summary>
    /// Registering your Page for navigation is essentially mapping a unique identifier/key
    /// to the target view during the bootstrapping process.
    ///
    /// See: https://prismlibrary.com/docs/xamarin-forms/navigation/navigation-basics.html
    /// </summary>
    /// <param name="containerRegistry"></param>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      AppLogger.Log.Trace("");
      containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
      containerRegistry.RegisterForNavigation<BodyRegionView, BodyRegionViewModel>();

      containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
    }

    /// <summary>
    /// The ViewModelLocator is used to wire the DataContext of a view to an instance of a ViewModel using a standard naming convention.
    ///
    /// See: https://prismlibrary.com/docs/viewmodel-locator.html
    /// </summary>
    protected override void ConfigureViewModelLocator()
    {
      base.ConfigureViewModelLocator();

      // type / type
      //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), typeof(CustomViewModel));

      // type / factory
      //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), () => Container.Resolve<CustomViewModel>());

      // generic factory
      //ViewModelLocationProvider.Register<MainWindow>(() => Container.Resolve<CustomViewModel>());

      // generic type
      ViewModelLocationProvider.Register<BodyRegionView, BodyRegionViewModel>();
      ViewModelLocationProvider.Register<CustomBodyRegionView, CustomBodyRegionViewModel>();
      ViewModelLocationProvider.Register<PublisherView, PublisherViewModel>();
      ViewModelLocationProvider.Register<SubscriberView, SubscriberViewModel>();
    }
    

    /// <summary>
    /// The most basic module catalog is provided by the ModuleCatalog class.
    /// You can use this module catalog to programmatically register modules by specifying the module class type.
    /// You can also programmatically specify the module name and initialization mode.
    ///
    /// See: https://prismlibrary.com/docs/wpf/legacy/Modules.html#registering-modules-in-code
    /// </summary>
    /// <param name="moduleCatalog"></param>
    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
      // TODO
      AppLogger.Log.Trace("");
    }
  }
}
