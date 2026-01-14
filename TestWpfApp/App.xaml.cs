using Serilog;
using System.Windows;

namespace TestWpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.WriteTo.File($"test-sms-wpf-app-{DateTime.Now:yyyyMMdd}.log")
			.CreateLogger();

		Log.Information("Приложение запущено");

#if RELEASE
		    
			AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
		    {
			Log.Error("Произошла непредвиденная ошибка: {error}", args.ExceptionObject);

			    MessageBox.Show($"Произошла непредвиденная ошибка: {args.ExceptionObject}");
		    };
#endif

	}
}