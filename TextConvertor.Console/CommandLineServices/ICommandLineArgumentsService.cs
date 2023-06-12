using TextConvertor.Console.CommandLineServices.Models;

namespace TextConvertor.Console.CommandLineServices;

public interface ICommandLineArgumentsService
{
    UserResponse ParseUserCommand( string line );

    string BuildHelpMessage();
    
    string HelpCommand { get; }
}