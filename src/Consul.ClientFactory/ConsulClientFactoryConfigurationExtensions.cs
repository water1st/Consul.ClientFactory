using Microsoft.Extensions.DependencyInjection;
using System;

namespace Consul.ClientFactory
{
    public static class ConsulClientFactoryConfigurationExtensions
    {
        public static IServiceCollection AddConsulClient(this IServiceCollection services, Action<ConsulClientConfiguration> options)
        {
            services.Configure(options);
            services.AddTransient<IConsulClientFactory, ConsulClientFactory>();
            services.AddTransient(provider =>
            {
                var factory = provider.GetService<IConsulClientFactory>();
                var client = factory.Create();
                return client;
            });

            return services;
        }

        public static IServiceCollection AddConsulClient(this IServiceCollection services, string name, Action<ConsulClientConfiguration> options)
        {
            services.Configure(name, options);
            services.AddTransient<IConsulClientFactory, ConsulClientFactory>();

            return services;
        }
    }
}
