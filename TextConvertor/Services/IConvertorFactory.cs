using TextConvertor.Models;

namespace TextConvertor.Services;

public interface IConvertorFactory
{
    IConvertor Build(
        ConvertingDestinationType destinationType,
        SanitizerType sanitizerType,
        IUserMessageHandler? messageHandler = null );
}