using TextConvertor.Services;

namespace TextConvertor.Console;

public class ConsoleMessageHandler : IUserMessageHandler
{
    public void SendMessage( string message )
    {
        System.Console.WriteLine( message );
    }
}