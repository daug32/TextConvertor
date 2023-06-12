using System.Text;
using Mono.Options;

namespace TextConvertor.Console.CommandLineServices.Implementation.Extensions;

public static class OptionSetExtension
{
    public static string BuildOptionDescriptions( this OptionSet optionSet )
    {
        using var memoryStream = new MemoryStream();
        
        using TextWriter writer = new StreamWriter( memoryStream );
        optionSet.WriteOptionDescriptions( writer );
        writer.Flush();

        byte[] buffer = memoryStream.ToArray();
        return Encoding.ASCII.GetString( buffer );
    }
}