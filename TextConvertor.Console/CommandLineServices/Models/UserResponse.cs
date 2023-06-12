namespace TextConvertor.Console.CommandLineServices.Models;

public class UserResponse
{
    public UserResponse(
        UserActionType userAction,
        string? sourceFile = null,
        string? destinationFile = null )
    {
        SourceFile = sourceFile;
        UserAction = userAction;
        DestinationFile = destinationFile;
    }

    public UserActionType UserAction { get; set; }
    public string? SourceFile { get; set; }
    public string? DestinationFile { get; set; }
}