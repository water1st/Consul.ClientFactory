# Consul.ClientFactory

### Getting started
To use the cluster client factory, first install the [NuGet package](https://www.nuget.org/packages/Consul.ClientFactory/):

```powershell
Install-Package Consul.ClientFactory
``` 


Next, register to IServiceCollection
```csharp
            services.AddConsulClient(config =>
            {
                config.Address = new Uri("http://localhost:8080");
                config.Datacenter = "dc1";
            });
```
Injection the IConsulClientFactory to the constructor
```csharp
    public class TestClass
    {
        private readonly IConsulClientFactory factory;

        public TestClass(IConsulClientFactory factory)
        {
            this.factory = factory;
        }

        public void Test()
        {
            using (var client = factory.Create())
            {
                //do something
            }
        }
     }
```
or injection the IConsulClient
```casharp
    public class TestClass : IDisposable
    {
        private readonly IConsulClient client;

        public TestClass(IConsulClient client)
        {
            this.client = client;
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
```

#### Register the client by name

```csharp
            services.AddConsulClient("consul1", config =>
            {
                config.Address = new Uri("http://localhost:8081");
                config.Datacenter = "dc1";
            });
            services.AddConsulClient("consul2", config =>
            {
                config.Address = new Uri("http://localhost:8082");
                config.Datacenter = "dc2";
            });
```

get the client by name

```cashap
            using (var client = factory.Create("consul1"))
            {
                //do something
            }
```
