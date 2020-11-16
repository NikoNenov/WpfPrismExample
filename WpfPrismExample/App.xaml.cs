using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using WpfPrismExample.Utilities;
using WpfPrismExample.Views;
using WpfPrismExample.ViewModels;

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
      containerRegistry.RegisterForNavigation<BodyRegionViewModel, BodyRegionViewModel>();
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
