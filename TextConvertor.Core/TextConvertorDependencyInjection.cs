using Microsoft.Extensions.DependencyInjection;
using TextConvertor.Core.Implementation;
using TextConvertor.Core.Sanitizers;

namespace TextConvertor.Core;

public static class TextConvertorDependencyInjection
{
    public static IServiceCollection AddTextConvertorDependencies( this IServiceCollection services )
    {
        services.AddScoped<IFileSanitizer, FileSanitizer>();
        services.AddScoped<IStringSanitizer, FicbookStringSanitizer>();

        return services;
    }
}