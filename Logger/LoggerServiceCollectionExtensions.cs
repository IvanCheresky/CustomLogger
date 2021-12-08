using Logger.Data;
using LoggerExercise.Logger.Configurations;
using LoggerExercise.Logger.Data.Interfaces;
using LoggerExercise.Logger.Data.Repositories;
using LoggerExercise.Logger.Services;
using LoggerExercise.Logger.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace LoggerExercise.Logger
{
    public static class LoggerServiceCollectionExtensions
    {
        public static IServiceCollection AddLogger(this IServiceCollection services,
            Action<LoggerConfiguration> configuration, string connectionString)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddOptions();

            services.Configure<LoggerConfiguration>(configuration);

            services.AddScoped<ILoggingService, LoggingService>();

            services.TryAddScoped<ILogRepository, LogRepository>();

            services.AddScoped<ILogger, ConsoleLogger>();
            services.AddScoped<ILogger, FileLogger>();
            services.AddScoped<ILogger, DbLogger>();

            services.AddDbContext<ILogDbContext, LogDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}