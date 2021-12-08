using System;
using System.Collections.Generic;
using Logger;
using Logger.Data.Interfaces;
using Logger.Data.Repositories;
using Logger.Models;
using Logger.Services;
using LoggerExercise.Data;
using LoggerExercise.Data.Interfaces;
using LoggerExercise.Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Logger.Services.Interfaces;
using LoggerExercise.Example;
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

            services.AddDbContext<IExerciseDbContext, ExerciseDbContext>(options => options.UseSqlServer(connectionStrings.ExerciseDbContext));

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetService<ExerciseDbContext>();

            services.AddLogger(lc =>
                {
                    lc.LogLevels = new List<LogLevel>() {LogLevel.Error};
                    lc.LogTypes = new List<LogTypes>() {LogTypes.Db};
                },
                context
            );

            services.AddScoped<ILogUseExample, LogUseExample>();
        }
    }
}
