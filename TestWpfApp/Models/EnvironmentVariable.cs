using CommunityToolkit.Mvvm.ComponentModel;
using Serilog;

namespace TestWpfApp.Models;

public partial class EnvironmentVariable : ObservableObject
{
	private readonly EnvironmentVariableService _service;

	[ObservableProperty] private string _name;
	[ObservableProperty] private string _comment;
	private string _value;

	public EnvironmentVariable(EnvironmentVariableService service)
	{
		_service = service;
	}

	public string Value
	{
		get => _value;
		set
		{
			var oldValue = _value;
			SetProperty(ref _value, value);
			if (oldValue != null)
			{
				Log.Information("Значение переменной {variable} изменено: {Old} -> {New}", Name, oldValue, value);
				_service.SaveVariable(this);
			}
		}
	}
}