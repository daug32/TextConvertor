using TextConvertor.Core;

namespace TextConvertor.Console.TextConvertorHandlers;

public class ConsoleMessageHandler : IUserMessageHandler
{
    public void SendMessage( string message )
    {
        System.Console.WriteLine( message );
    }
}