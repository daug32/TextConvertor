using TextConvertor.Console.CommandLineServices;
using TextConvertor.Console.CommandLineServices.Models;
using TextConvertor.Console.Extensions;
using TextConvertor.Console.TextConvertorHandlers;
using TextConvertor.Core.Sanitizers;

namespace TextConvertor.Console;

public class TextConvertorApplication
{
    private readonly IUiService _uiService;
    private readonly IFileSanitizer _fileSanitizer;

    public TextConvertorApplication(
        IFileSanitizer fileSanitizer,
        IUiService uiService )
    {
        _fileSanitizer = fileSanitizer;
        _fileSanitizer.ProgressNotificator = new ConsoleMessageHandler();
        _uiService = uiService;
    }

    public void Start()
    {
        _uiService.PrintApplicationStartedMessage();

        while ( true )
        {
            _uiService.PrintEnterCommandMessage();

            UserResponse response = _uiService.AskForCommand();
            if ( response.UserAction == UserActionType.Unknown )
            {
                _uiService.PrintCommandIsNotRecognizedMessage();
                continue;
            }
                
            if ( response.UserAction == UserActionType.Exit )
            {
                break;
            }

            if ( response.UserAction == UserActionType.Help )
            {
                _uiService.PrintHelp();
                continue;
            }

            ProcessFileOnce( response.SourceFile! );
        }

        _uiService.PrintApplicationCompletedMessage();
    }

    private void ProcessFileOnce( string filePath )
    {
        filePath = SanitizeFilePath( filePath );
        if ( !File.Exists( filePath ) )
        {
            _uiService.PrintFileNotFoundMessage( filePath );
            return;
        }

        try
        {
            _fileSanitizer.Sanitize( filePath );
        }
        catch ( Exception ex )
        {
            _uiService.PrintExceptionMessage( $"File single processing. File path: {filePath}", ex );
        }
    }

    private static string SanitizeFilePath( string line )
    {
        return string.IsNullOrEmpty( line )
            ? String.Empty
            : Path.GetFullPath( line.RemoveQuotes() );
    }
}