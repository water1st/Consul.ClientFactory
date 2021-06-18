using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Consul.ClientFactory
{
    public static class ConsulClientFactoryConfigurationExtensions
    {
        public static IServiceCollection AddConsulClient(this IServiceCollection services, Action<ConsulClientConfiguration> options)
        {
            services.Configure(options);
            services.TryAddTransient<IConsulClientFactory, ConsulClientFactory>();
            services.TryAddTransient(provider =>
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
            services.TryAddTransient<IConsulClientFactory, ConsulClientFactory>();

            return services;
        }
    }
}
