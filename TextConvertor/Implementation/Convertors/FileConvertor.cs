using TextConvertor.Services;

namespace TextConvertor.Implementation.Convertors;

internal class FileConvertor : IConvertor, IDisposable
{
    private readonly IStringSanitizer _stringSanitizer;

    private string? _tempFilePath;
    private Timer? _timer;

    public FileConvertor( IStringSanitizer stringSanitizer )
    {
        _stringSanitizer = stringSanitizer;
    }

    public IUserMessageHandler? MessageHandler { get; set; } = null;

    public void Convert( string filePath )
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

        _timer?.Dispose();
    }

    private void CopyToMainFile( string mainFilePath, string tempFilePath )
    {
        MessageHandler?.SendMessage( "Commiting changes..." );

        File.Copy( tempFilePath, mainFilePath, true );
    }

    private void SanitizeToTemporaryFile( string mainFilePath, string tempFilePath )
    {
        using var writer = new StreamWriter( tempFilePath );

        IEnumerable<string> lines = File.ReadAllLines( mainFilePath );

        int numberOfLines = lines.Count();
        
        var index = 0;
        double currentProgress = 0;
        double progress = 0;
        
        _timer = new Timer( 
            _ => ShowProgress( CalculateProgress( index, numberOfLines ), ref progress ),
            null,
            0,
            1000 );

        foreach ( string line in lines )
        {
            writer.WriteLine( _stringSanitizer.Sanitize( line ) );
            index++;
        }

        _timer.Dispose();
    }

    private void ShowProgress( double currentProgress, ref double oldProgress )
    {
        if ( currentProgress - oldProgress > 1 )
        {
            MessageHandler?.SendMessage( $"Progress: {currentProgress}%" );
            oldProgress = currentProgress;
        }
    }

    private double CalculateProgress( int index, int numberOfLines )
    {
        return Math.Round( index / ( double )numberOfLines * 100, 4 );
    }

    private string GetTemporaryFilePath()
    {
        return $"./temp_{DateTime.Now.Ticks.ToString()}";
    }
}