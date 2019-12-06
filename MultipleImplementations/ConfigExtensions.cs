using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MultipleImplementations
{
    public static class ConfigExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                                    .AddInMemoryCollection()
                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                    .Build();

            services.AddSingleton<IConfiguration>(builder);

            return services;
        }
    }
}
