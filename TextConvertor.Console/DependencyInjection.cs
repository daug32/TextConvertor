using Microsoft.Extensions.DependencyInjection;

namespace TextConvertor.Console;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencies( this IServiceCollection services )
    {
        services.AddScoped<TextConvertorApplication>();
        services.AddTextConvertorDependencies();
        
        return services;
    }
}