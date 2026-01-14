using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using Serilog;
using TestWpfApp.Models;

namespace TestWpfApp;

public partial class MainViewModel : ObservableObject
{
	private readonly EnvironmentVariableService _service;

	[ObservableProperty] private ObservableCollection<EnvironmentVariable> _variables;

	public MainViewModel()
	{
		_service = new EnvironmentVariableService();
		_variables = [];
		LoadVariables();
	}

	private void LoadVariables()
	{
		try
		{
			var loadedVariables = _service.LoadVariables();

			foreach (var variable in loadedVariables)
				Variables.Add(variable);
			Log.Information("Переменные загружены");
		}
		catch (Exception ex)
		{
			Log.Error("Загрузка переменных завершилась ошибкой {error}", ex.Message);
			MessageBox.Show($"Ошибка загрузки: {ex.Message}");
		}
	}
}