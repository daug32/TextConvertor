using TextConvertor.Console.CommandLineServices.Models;

namespace TextConvertor.Console.CommandLineServices.Implementation;

internal class ConsoleUiService : IUiService
{
    private readonly ICommandLineArgumentsService _commandLineArgumentsService;

    public ConsoleUiService( ICommandLineArgumentsService commandLineArgumentsService )
    {
        _commandLineArgumentsService = commandLineArgumentsService;
    }

    public void PrintApplicationCompletedMessage()
    {
        System.Console.WriteLine( "Text convertor completed" );
    }

    public void PrintFileNotFoundMessage( string filePath )
    {
        System.Console.WriteLine( $"File not found. Path: {filePath}" );
    }

    public void PrintCommandIsNotRecognizedMessage()
    {
        System.Console.WriteLine( "Command is not recognized" );
    }

    public UserResponse AskForCommand()
    {
        string? line = System.Console.ReadLine();
        return _commandLineArgumentsService.ParseUserCommand( line );
    }

    public void PrintEnterCommandMessage()
    {
        System.Console.WriteLine( $"Enter file path or any command. To get all supported commands type \"{_commandLineArgumentsService.HelpCommand}\"" );
    }

    public void PrintApplicationStartedMessage()
    {
        System.Console.WriteLine( "Text convertor started in console." );
    }

    public void PrintExceptionMessage( string details, Exception ex )
    {
        string message =
            "An error occured while trying to validate file.\n"
            + $"Details: {details}\n"
            + $"Message: {ex.Message}\n"
            + $"Stacktrace: {ex.StackTrace}";
        System.Console.WriteLine( message );
    }

    public void PrintHelp()
    {
        System.Console.WriteLine( _commandLineArgumentsService.BuildHelpMessage() );
    }
}