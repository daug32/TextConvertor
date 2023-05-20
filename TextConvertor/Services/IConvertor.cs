namespace TextConvertor.Services;

public interface IConvertor
{
    /// <summary>
    ///     Used to send notifications about progress
    /// </summary>
    IUserMessageHandler MessageHandler { get; set; }
    
    void Convert( string filePath );
}