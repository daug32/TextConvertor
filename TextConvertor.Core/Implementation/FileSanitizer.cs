using TextConvertor.Core.Sanitizers;

namespace TextConvertor.Core.Implementation;

internal class FileSanitizer : IFileSanitizer
{
    private string? _tempFilePath;
    private readonly ProgressTimerNotifier _progressTimerNotifier = new();
    private readonly IStringSanitizer _stringSanitizer;

    public IUserMessageHandler? ProgressNotificator { get; set; } = null;

    public FileSanitizer( IStringSanitizer stringSanitizer )
    {
        _stringSanitizer = stringSanitizer;
    }

    public void Sanitize( string filePath )
    {
        _tempFilePath = GetTemporaryFilePath();

        SanitizeToTemporaryFile( filePath, _tempFilePath );
        CopyToMainFile( filePath, _tempFilePath );

        File.Delete( _tempFilePath );
    }

    public void Dispose()
    {
        if ( _tempFilePath != null )
        {
            File.Delete( _tempFilePath );
        }

        _progressTimerNotifier.StopIfRunning();
    }

    private void CopyToMainFile( string mainFilePath, string tempFilePath )
    {
        ProgressNotificator?.SendMessage( "Commiting changes..." );

        File.Copy( tempFilePath, mainFilePath, true );
    }

    private void SanitizeToTemporaryFile( string mainFilePath, string tempFilePath )
    {
        IEnumerable<string> lines = File.ReadAllLines( mainFilePath );
        int numberOfLines = lines.Count();

        using var writer = new StreamWriter( tempFilePath );

        _progressTimerNotifier.Start( numberOfLines, message => ProgressNotificator?.SendMessage( message ) );

        foreach ( string line in lines )
        {
            writer.WriteLine( _stringSanitizer.Sanitize( line ) );
            _progressTimerNotifier.CurrentStepNumber++;
        }

        _progressTimerNotifier.StopIfRunning();
    }

    private static string GetTemporaryFilePath()
    {
        return $"./temp_{DateTime.Now.Ticks.ToString()}";
    }
}