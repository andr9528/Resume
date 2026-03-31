using Microsoft.Extensions.DependencyInjection;

namespace Resume.Abstraction.Interfaces.Startup;

public interface IServiceStartupModule
{
    void ConfigureServices(IServiceCollection services);
    string Name { get; }
}
