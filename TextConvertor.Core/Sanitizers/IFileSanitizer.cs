namespace TextConvertor.Core.Sanitizers;

public interface IFileSanitizer : IDisposable
{
    /// <summary>
    ///     Used to send notifications about progress
    /// </summary>
    IUserMessageHandler? ProgressNotificator { get; set; }
    
    void Sanitize( string filePath );
}