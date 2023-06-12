using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TextConvertor.Console;

public class Program
{
    private static void Main( string[] args )
    {
        BuildHost()
            .Services
            .GetRequiredService<TextConvertorApplication>()
            .Start();
    }

    private static IHost BuildHost()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(
                services => services.ConfigureDependencies() )
            .Build();
    }
}