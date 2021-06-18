using Microsoft.Extensions.Options;

namespace Consul.ClientFactory
{
    internal class ConsulClientFactory : IConsulClientFactory
    {
        private readonly IOptionsMonitor<ConsulClientConfiguration> options;

        public ConsulClientFactory(IOptionsMonitor<ConsulClientConfiguration> options)
        {
            this.options = options;
        }

        public IConsulClient Create()
        {
            var options = this.options.CurrentValue;
            var client = new ConsulClient(options);
            return client;
        }

        public IConsulClient Create(string name)
        {
            var options = this.options.Get(name);
            var client = new ConsulClient(options);
            return client;
        }
    }
}
