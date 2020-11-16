using System.Windows;
using Prism.Commands;
using WpfPrismExample.Utilities;

namespace WpfPrismExample.ViewModels
{
  public class BodyRegionViewModel : BaseViewModel
  {
    private bool _isEnabled;

    public bool IsEnabled
    {
      get => _isEnabled;
      set => SetProperty(ref _isEnabled, value);
    }

    public DelegateCommand ButtonACommand { get; }

    public BodyRegionViewModel()
    {
      AppLogger.Log.Trace("");
      _isEnabled = true;
      ButtonACommand = new DelegateCommand(ExecuteButtonA).ObservesCanExecute(() => IsEnabled);
    }

    private void ExecuteButtonA()
    {
      MessageBox.Show("Execute BodyRegionViewModel.ButtonA command", "Action BodyRegionViewModel.ButtonA");
    }
  }
}
