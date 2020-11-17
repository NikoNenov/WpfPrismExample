using System.Windows;
using Prism.Commands;
using WpfPrismExample.Utilities;

namespace WpfPrismExample.ViewModels
{
  public class BodyRegionViewModel : BaseViewModel
  {
    private bool _isEnabled;

    public DelegateCommand ButtonACommand { get; }
    public DelegateCommand ButtonBCommand { get; }
    public DelegateCommand ButtonFCommand { get; }

    public bool IsEnabled
    {
      get => _isEnabled;
      set => SetProperty(ref _isEnabled, value);
    }

    public BodyRegionViewModel()
    {
      AppLogger.Log.Trace("");
      _isEnabled = true;

      ButtonACommand = new DelegateCommand(ExecuteButtonA, CanExecuteButtonA);

      ButtonBCommand = new DelegateCommand(ExecuteButtonB);

      ButtonFCommand = new DelegateCommand(ExecuteButtonF).ObservesCanExecute(() => IsEnabled);
    }

    /// <summary>
    /// Button A action
    /// </summary>
    private void ExecuteButtonA()
    {
      MessageBox.Show("Execute BodyRegionViewModel.ButtonA command", "Action BodyRegionViewModel.ButtonA");
    }

    /// <summary>
    /// Can execute button A action
    /// </summary>
    /// <returns></returns>
    private bool CanExecuteButtonA()
    {
      // TODO validation
      return true;
    }

    /// <summary>
    /// Button B action
    /// </summary>
    private void ExecuteButtonB()
    {
      MessageBox.Show("Execute BodyRegionViewModel.ButtonB command", "Action BodyRegionViewModel.ButtonB");
    }

    /// <summary>
    /// Button F action
    /// </summary>
    private void ExecuteButtonF()
    {
      MessageBox.Show("Execute BodyRegionViewModel.ButtonF command", "Action BodyRegionViewModel.ButtonF");
    }
  }
}
