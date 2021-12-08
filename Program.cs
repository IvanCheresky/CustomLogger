﻿using System;
using Logger.Services;
using LoggerExercise.Data;
using LoggerExercise.Data.Interfaces;
using LoggerExercise.Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Logger.Services.Interfaces;
using LoggerExercise.Data.Repositories;
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

            services.AddScoped<ILoggingService, LoggingService>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILogUseExample, LogUseExample>();
        }
    }
}