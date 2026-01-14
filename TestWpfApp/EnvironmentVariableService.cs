using Microsoft.Extensions.Configuration;
using TestWpfApp.Models;

namespace TestWpfApp;

public class EnvironmentVariableService
{
	private readonly IConfiguration _configuration;
	private const string ConfigFile = "appsettings.json";

	public EnvironmentVariableService()
	{
		_configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile(ConfigFile, optional: false, reloadOnChange: false)
			.Build();
	}

	public List<EnvironmentVariable> LoadVariables()
	{
		var configSection = _configuration.GetSection("Variables");

		var configList = new List<EnvironmentVariable>();

		if (configSection.Exists())
		{
			configList = configSection.GetChildren()
				.Select(section => new EnvironmentVariable(this)
				{
					Name = section.GetSection("Name").Value ?? string.Empty,
					Value = section.GetSection("Value").Value ?? string.Empty,
					Comment = section.GetSection("Comment").Value ?? string.Empty
				})
				.ToList();
		}

		if (configList.Count == 0) configList = GetDefaultConfig();


		var variables = new List<EnvironmentVariable>();

		foreach (var varConfig in configList)
		{
			if (string.IsNullOrWhiteSpace(varConfig.Name))
				continue;

			var currentValue = Environment.GetEnvironmentVariable(varConfig.Name, EnvironmentVariableTarget.User);
			if (currentValue == null)
			{
				currentValue = varConfig.Value;
			}

			variables.Add(new EnvironmentVariable(this)
			{
				Name = varConfig.Name,
				Value = currentValue,
				Comment = varConfig.Comment
			});
		}

		return variables;
	}

	public void SaveVariable(EnvironmentVariable variable) => Environment.SetEnvironmentVariable(variable.Name, variable.Value, EnvironmentVariableTarget.User);

	private List<EnvironmentVariable> GetDefaultConfig() =>
	[
		new(this)
		{
			Name = "TESTAPP_PATH",
			Value = @"C:\TESTAPP",
			Comment = "Расположение приложения"
		},

		new(this)
		{
			Name = "TESTAPP_LOGGING_LEVEL",
			Value = "INFO",
			Comment = "Уровень логирования"
		},

		new(this)
		{
			Name = "TESTAPP_CACHE_SIZE",
			Value = "10",
			Comment = "Размер кэша"
		}
	];
}