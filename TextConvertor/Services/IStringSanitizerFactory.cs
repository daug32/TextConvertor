using TextConvertor.Models;

namespace TextConvertor.Services;

public interface IStringSanitizerFactory
{
    IStringSanitizer Build( SanitizerType sanitizerType );
}