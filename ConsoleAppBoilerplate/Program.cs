using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ConsoleAppBoilerplate
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var builder = InstantiateHostBuilder();
				using (var host = builder.Build())
				{
					Console.WriteLine("Application is starting");

					var baseClassObj = ActivatorUtilities
						.CreateInstance<BaseClass>(
							host.Services);

					baseClassObj.Run();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				Log.CloseAndFlush();
				Console.WriteLine("Application is stopped");
			}
		}

		private static IHostBuilder InstantiateHostBuilder()
		{
			var builder = new HostBuilder()
				.ConfigureHostConfiguration(config => config.AddEnvironmentVariables())
				.ConfigureAppConfiguration(
					(hostContext, configurationBuilder) =>
					{
						// Add settings file
						configurationBuilder
							.SetBasePath(FilePathInfo.BasePath)
							.AddJsonFile("appsettings.json", optional: true);

						if (hostContext.HostingEnvironment.IsDevelopment())
						{
							configurationBuilder
								.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
						}
					})
				.ConfigureServices(
					(hostContext, serviceCollection) =>
					{
						ConfigureDependencies(hostContext.Configuration, serviceCollection);
					})
				.ConfigureLogging(
					(hostContext, logging) =>
					{
						// Remove all existing loggers that have been added by default.
						logging.ClearProviders();

						// Setup the Serilog logger.
						SetupStaticLogger(FilePathInfo.BasePath);

						// Add the Serilog logger.
						logging.AddSerilog(logger: Log.Logger, dispose: true);
					})
				.UseConsoleLifetime();

			return builder;
		}

		private static void ConfigureDependencies(IConfiguration configuration, IServiceCollection serviceCollection)
		{
			// Register all the services
			serviceCollection.AddTransient<GuidDataTableService>();
			serviceCollection.AddTransient<IdentityDataTableService>();
			serviceCollection.AddSingleton<DataTableServiceResolver>();
		}

		private static void SetupStaticLogger(string loggerFilePath)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(loggerFilePath)
				.AddJsonFile("logsettings.json")
				.Build();

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();
		}
	}
}