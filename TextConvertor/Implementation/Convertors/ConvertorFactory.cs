using TextConvertor.Models;
using TextConvertor.Services;

namespace TextConvertor.Implementation.Convertors;

internal class ConvertorFactory : IConvertorFactory
{
    private readonly IStringSanitizerFactory _stringSanitizerFactory;

    public ConvertorFactory( IStringSanitizerFactory stringSanitizerFactory )
    {
        _stringSanitizerFactory = stringSanitizerFactory;
    }

    public IConvertor Build(
        ConvertingDestinationType destinationType,
        SanitizerType sanitizerType,
        IUserMessageHandler? messageHandler = null )
    {
        IStringSanitizer stringSanitizer = _stringSanitizerFactory.Build( sanitizerType );
        
        IConvertor convertor = BuildWithSanitizer( 
            destinationType,
            stringSanitizer );
        
        if ( messageHandler != null )
        {
            convertor.MessageHandler = messageHandler;
        }

        return convertor;
    }

    private static IConvertor BuildWithSanitizer(
        ConvertingDestinationType destinationType,
        IStringSanitizer stringSanitizer )
    {
        return destinationType switch
        {
            ConvertingDestinationType.File => new FileConvertor( stringSanitizer ),
            _ => throw new ArgumentOutOfRangeException( nameof( destinationType ) )
        };
    }
}