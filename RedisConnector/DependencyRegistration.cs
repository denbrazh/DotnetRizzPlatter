using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisConnector.Models;
using StackExchange.Redis;

namespace RedisConnector;

public static class DependencyRegistration
{
    public static IServiceCollection AddRedisConnector(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConfig = configuration.GetSection("RedisConfig").Get<RedisConfig>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.ConfigurationOptions = new ConfigurationOptions();
            if (redisConfig != null)
                foreach (var host in redisConfig.RedisHosts)
                {
                    options.ConfigurationOptions.EndPoints.Add(new StringBuilder().Append(host.Host)
                        .Append(":")
                        .Append(host.Port)
                        .ToString());
                }
        });
        return services;
    }
}