using System.Windows;
using Prism.Commands;
using WpfPrismExample.Utilities;

namespace WpfPrismExample.ViewModels.Regions
{
  public class BodyRegionViewModel : BaseViewModel
  {
    private bool _isEnabled;

    public DelegateCommand ShowMessageACommand { get; }
    public DelegateCommand ShowMessageBCommand { get; }
    public DelegateCommand ShowMessageFCommand { get; }

    public bool IsEnabled
    {
      get => _isEnabled;
      set => SetProperty(ref _isEnabled, value);
    }

    public BodyRegionViewModel()
    {
      AppLogger.Log.Trace("");
      _isEnabled = true;

      ShowMessageACommand = new DelegateCommand(ExecuteShowMessageA, CanExecuteShowMessageA);

      ShowMessageBCommand = new DelegateCommand(ExecuteShowMessageB);

      ShowMessageFCommand = new DelegateCommand(ExecuteShowMessageF).ObservesCanExecute(() => IsEnabled);
    }

    /// <summary>
    /// Button A action
    /// </summary>
    private void ExecuteShowMessageA()
    {
      MessageBox.Show( "Execute show message A");
    }

    /// <summary>
    /// Can execute button A action
    /// </summary>
    /// <returns></returns>
    private bool CanExecuteShowMessageA()
    {
      // TODO validation
      return true;
    }

    /// <summary>
    /// Button B action
    /// </summary>
    private void ExecuteShowMessageB()
    {
      MessageBox.Show("Execute show message B");
    }

    /// <summary>
    /// Button F action
    /// </summary>
    private void ExecuteShowMessageF()
    {
      MessageBox.Show( "Execute show message F");
    }
  }
}
