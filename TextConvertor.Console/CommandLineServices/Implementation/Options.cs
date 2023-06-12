using TextConvertor.Console.CommandLineServices.Models;

namespace TextConvertor.Console.CommandLineServices.Implementation;

internal class Options
{
    public bool NeedHelp { get; set; }

    public bool NeedToExit { get; set; }

    public bool ProcessFileOnce { get; set; }

    public string? SourceFilePath { get; set; }
        
    public string? DestinationFilePath { get; set; }

    public UserActionType GetUserActionType()
    {
        if ( NeedHelp )
        {
            return UserActionType.Help;
        }

        if ( NeedToExit )
        {
            return UserActionType.Exit;
        }

        if ( ProcessFileOnce )
        {
            return UserActionType.ProcessFileOnce;
        }

        return UserActionType.Unknown;
    }
}