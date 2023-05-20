using TextConvertor.Models;
using TextConvertor.Services;

namespace TextConvertor.Console;

public class TextConvertorApplication
{
    private readonly IConvertorFactory _convertorFactory;

    public TextConvertorApplication( IConvertorFactory convertorFactory )
    {
        _convertorFactory = convertorFactory;
    }

    public void Start()
    {
        System.Console.WriteLine( "Text convertor started in console." );

        while ( true )
        {
            System.Console.WriteLine( "Enter file path or any command. To get all supported commands type \"help\"" );

            string line = System.Console.ReadLine()!;
            if ( NeedToExit( line ) )
            {
                break;
            }

            if ( NeedToPrintHelp( line ) )
            {
                PrintHelp();
                continue;
            }

            string filePath = SanitizeFilePath( line );
            if ( !File.Exists( filePath ) )
            {
                System.Console.WriteLine( $"File not found. Path: {filePath}" );
                continue;
            }

            SanitizeFile( filePath );
        }

        System.Console.WriteLine( "Text convertor completed" );
    }

    private void SanitizeFile( string path )
    {
        IConvertor convertor = _convertorFactory.Build(
            ConvertingDestinationType.File,
            SanitizerType.Ficbook,
            new ConsoleMessageHandler() );

        try
        {
            convertor.Convert( path );
        }
        catch ( Exception ex )
        {
            PrintExceptionMessage( path, ex );
        }
    }

    private static string SanitizeFilePath( string line )
    {
        if ( string.IsNullOrEmpty( line ) )
        {
            return String.Empty;
        }

        string path = line;
        
        if ( path.First() == '\"' )
        {
            path = path.Remove( 0, 1 );
        }

        if ( path.Last() == '\"' )
        {
            path = path.Remove( path.Length - 1, 1 );
        }

        if ( String.IsNullOrWhiteSpace( path ) )
        {
            return String.Empty;
        }
        
        return Path.GetFullPath( path );
    }

    private static bool NeedToExit( string line )
    {
        return line == "exit";
    }

    private static bool NeedToPrintHelp( string line )
    {
        return line == "help";
    }

    private static void PrintExceptionMessage( string filePath, Exception ex )
    {
        string message =
            "An error occured while trying to validate file.\n"
            + $"File path: {filePath}\n"
            + $"Message: {ex.Message}\n"
            + $"Stacktrace: {ex.StackTrace}";
        System.Console.WriteLine( message );
    }

    private static void PrintHelp()
    {
        string message =
            "Enter file path to process file.\n"
            + "\"help\" -- shows this message.\n"
            + "\"exit\" -- exit from application.";
        System.Console.WriteLine( message );
    }
}