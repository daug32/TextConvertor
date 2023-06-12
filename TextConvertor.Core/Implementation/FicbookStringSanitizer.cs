using System.Text.RegularExpressions;
using TextConvertor.Core.Implementation.Extensions;
using TextConvertor.Core.Implementation.Models;
using TextConvertor.Core.Sanitizers;

namespace TextConvertor.Core.Implementation;

internal class FicbookStringSanitizer : IStringSanitizer
{
    private readonly IReadOnlyList<KeyValuePair<string, string>> _stringReplaces =
        new List<KeyValuePair<string, string>>
        {
            new( "--", Symbols.Dash ),
            new( "...", Symbols.ThreePointsSymbol )
        };

    private readonly IReadOnlyList<KeyValuePair<string, string>> _regexReplaces = 
        new List<KeyValuePair<string, string>>
        {
            new( @"^-", Symbols.Dash ),
            new( @"(?<before>[^\s]) -(?<after>[^\s])|(?<before>[^\s])- (?<after>[^\s])", "${before}-${after}" )
        };

    public string Sanitize( string str )
    {
        if ( String.IsNullOrEmpty( str ) )
        {
            return string.Empty;
        }

        string result = str.TrimAndRemoveConsecutiveSpaces();
        if ( result == "***" )
        {
            return Tags.Center.Append( result );
        }

        foreach ( KeyValuePair<string, string> replace in _stringReplaces )
        {
            result = result.Replace( replace.Key, replace.Value );
        }

        foreach ( KeyValuePair<string, string> replace in _regexReplaces )
        {
            result = Regex.Replace( result, replace.Key, replace.Value );
        }

        return result.AddTag( Tags.Tab );
    }
}