using Microsoft.Extensions.DependencyInjection;
using TextConvertor.Implementation.Convertors;
using TextConvertor.Implementation.StringSanitizers;
using TextConvertor.Services;

namespace TextConvertor;

public static class TextConvertorDependencyInjection
{
    public static IServiceCollection AddTextConvertorDependencies( this IServiceCollection services )
    {
        services.AddScoped<IConvertorFactory, ConvertorFactory>();
        services.AddScoped<IStringSanitizerFactory, StringSanitizerFactory>();

        return services;
    }
}