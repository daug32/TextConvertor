using TextConvertor.Console.CommandLineServices.Models;

namespace TextConvertor.Console.CommandLineServices;

public interface IUiService
{
    void PrintHelp();
    void PrintApplicationCompletedMessage();
    void PrintEnterCommandMessage();
    void PrintApplicationStartedMessage();
    
    void PrintFileNotFoundMessage( string filePath );
    void PrintExceptionMessage( string details, Exception ex );
    void PrintCommandIsNotRecognizedMessage();

    UserResponse AskForCommand();
}