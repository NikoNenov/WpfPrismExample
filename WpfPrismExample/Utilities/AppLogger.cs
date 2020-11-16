using NLog;

namespace WpfPrismExample.Utilities
{
  public static class AppLogger
  {

  /// <summary>
  /// NLog instance
  /// </summary>
  public static Logger Log { get; }

  /// <summary>
  /// Curtis logger default constructor
  /// </summary>
  static AppLogger()
  {
  LogManager.ReconfigExistingLoggers();
  Log = LogManager.GetCurrentClassLogger();
  }

  /// <summary>
  /// Dispose all targets, and shutdown logging.
  /// </summary>
  public static void Shutdown() => LogManager.Shutdown();
}
}
