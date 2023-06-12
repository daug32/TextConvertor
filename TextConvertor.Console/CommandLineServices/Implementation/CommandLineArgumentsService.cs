using Mono.Options;
using TextConvertor.Console.CommandLineServices.Implementation.Extensions;
using TextConvertor.Console.CommandLineServices.Models;

namespace TextConvertor.Console.CommandLineServices.Implementation;

internal class CommandLineArgumentsService : ICommandLineArgumentsService
{
    private readonly OptionSet _optionsSet;
    
    private Options _options = null!;

    public string HelpCommand => "--help";

    public CommandLineArgumentsService()
    {
        _optionsSet = new OptionSet
        {
            {
                "help",
                "Print this message",
                _ => _options.NeedHelp = true
            },
            {
                "exit",
                "Terminate application",
                _ => _options.NeedToExit = true
            },
            {
                "process",
                "Process source file for once",
                _ => _options.ProcessFileOnce = true
            },
            {
                "src=",
                "Source file path",
                path => _options.SourceFilePath = path
            },
            {
                "dest=",
                "Destination file path. If not specified, source file will be modified",
                dest => _options.DestinationFilePath = dest
            }
        };
    }

    public string BuildHelpMessage()
    {
        return _optionsSet.BuildOptionDescriptions();
    }
    
    public UserResponse ParseUserCommand( string line )
    {
        if ( String.IsNullOrWhiteSpace( line ) )
        {
            return new UserResponse( UserActionType.Unknown );
        }

        ParseOptions( line );

        return new UserResponse( 
            _options.GetUserActionType(),
            _options.SourceFilePath,
            _options.DestinationFilePath );
    }

    private void ParseOptions( string line )
    {
        IEnumerable<string> args = line
            .Split( ' ' )
            .Where( x => !String.IsNullOrWhiteSpace( x ) );

        _options = new Options();
        _optionsSet.Parse( args );
    }
}