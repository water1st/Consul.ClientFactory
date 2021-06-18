using System;

namespace Consul.ClientFactory
{
    public interface IConsulClientFactory
    {
        IConsulClient Create();
        IConsulClient Create(string name);
    }
}
