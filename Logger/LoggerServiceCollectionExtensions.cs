using System;
using Logger.Configurations;
using Logger.Data.Interfaces;
using Logger.Data.Repositories;
using Logger.Services;
using Logger.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Logger
{
    public static class LoggerServiceCollectionExtensions
    {
        public static IServiceCollection AddLogger(this IServiceCollection services,
            Action<ILoggerConfiguration> configuration, DbContext context)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.Configure(configuration);

            services.AddScoped<ILoggingService, LoggingService>();

            services.TryAddScoped<ILogRepository>(x => new LogRepository(context));

            return services;
        }
    }
}