using System;
using Prism.Mvvm;

namespace WpfPrismExample.ViewModels
{
  public class BaseViewModel : BindableBase
  {
    private string _title = $"Prism examples ({DateTime.Now:dd.MM.yyyy})";

    /// <summary>
    /// Application title
    /// </summary>
    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }
  }
}
