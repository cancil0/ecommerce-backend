using Core.IoC;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.Web;
using System.Reflection;

namespace Core.Extension
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder SetBuilder(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddConfiguration(SetConfigurationFile());
            SetLogManagerConfig();
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            builder.Services.AddMemoryCache(x => x.ExpirationScanFrequency = TimeSpan.FromMinutes(30));
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            builder.Services.AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssembly(Assembly.Load("Business"));
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.IntegrateSwagger();
            builder.Services.JwtSettings(builder.Configuration);
            builder.Services.AddDbContext(builder.Configuration);
            builder.Services.GetConfiguration(builder.Configuration);
            builder.Services.InjectServices();
            
            return builder;
        }

        private static IServiceCollection GetConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            Provider.Configuration = configuration;
            return services;
        }

        private static void SetLogManagerConfig()
        {
            var path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), "Configs", GetEnvironment(), "nlog.config");
            LogManager.LoadConfiguration(path);
        }

        private static IConfiguration SetConfigurationFile()
        {
            var configPath = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), "Configs", GetEnvironment());
            var config = new ConfigurationBuilder()
                 .SetBasePath(configPath)
                 .AddJsonFile("environment.json", false)
                 .Build();
            return config;
        }

        private static string GetEnvironment()
        {
#if DEBUG
            return "Development";
#else
            return "Production";
#endif
        }
    }
}
