using TextConvertor.Implementation.StringSanitizers.Ficbook;
using TextConvertor.Models;
using TextConvertor.Services;

namespace TextConvertor.Implementation.StringSanitizers;

internal class StringSanitizerFactory : IStringSanitizerFactory
{
    public IStringSanitizer Build( SanitizerType sanitizerType )
    {
        return sanitizerType switch
        {
            SanitizerType.Ficbook => new FicbookStringSanitizer(),
            _ => throw new ArgumentOutOfRangeException( nameof( sanitizerType ) )
        };
    }
}