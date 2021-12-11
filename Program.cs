using Logger;
using Logger.Configurations;
using LoggerExercise.Example;
using LoggerExercise.Settings;
using LoggerExercise.Settings.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LoggerExercise
{
    class Program
    {
        private static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            // configure appsettings, environment variables
            var builder = new ConfigurationBuilder();
            Configure(builder);

            // configure default builder and inject services
            using (var host = Host.CreateDefaultBuilder().ConfigureServices(ConfigureServices).Build())
            {
                // run example code
                var logUseExample = ActivatorUtilities.CreateInstance<LogUseExample>(host.Services);

                logUseExample.UseLogger();
            }
        }

        static void Configure(IConfigurationBuilder builder)
        {
            Configuration = builder.AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        static void ConfigureServices(IServiceCollection services)
        {
            ConnectionStrings connectionStrings = Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
            services.AddSingleton<IConnectionStrings>(connectionStrings);

            var config = Configuration.GetSection("LoggerConfiguration").Get<LoggerConfiguration>();

            // extension method for logger using a custom configuration
            services.AddLogger(lc =>
                {
                    lc.LogLevels = config.LogLevels;
                    lc.LogTypes = config.LogTypes;
                },
                connectionStrings.ConnectionString
            );

            services.AddScoped<ILogUseExample, LogUseExample>();
        }
    }
}
