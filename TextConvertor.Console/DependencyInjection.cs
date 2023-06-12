using Microsoft.Extensions.DependencyInjection;
using TextConvertor.Console.CommandLineServices;
using TextConvertor.Console.CommandLineServices.Implementation;
using TextConvertor.Core;

namespace TextConvertor.Console;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencies( this IServiceCollection services )
    {
        services.AddScoped<TextConvertorApplication>();
        services.AddScoped<IUiService, ConsoleUiService>();
        services.AddScoped<ICommandLineArgumentsService, CommandLineArgumentsService>();

        services.AddTextConvertorDependencies();
        
        return services;
    }
}