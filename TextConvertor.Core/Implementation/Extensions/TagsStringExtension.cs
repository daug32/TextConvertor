using System.Text.RegularExpressions;
using TextConvertor.Core.Implementation.Models;

namespace TextConvertor.Core.Implementation.Extensions;

internal static class TagsStringExtension
{
    public static string AddTag( this string str, Tag tag )
    {
        if ( tag != Tags.Tab )
        {
            return tag.Append( str );
        }

        var regex = @"^\s*\<\s*(\w*)\s*\>";
        Match matches = Regex.Match( str, regex );
        if ( !matches.Success )
        {
            return tag.Append( str );
        }

        string existingTag = matches.Groups[1].Value;

        if ( existingTag == Tags.Center.Name
             || existingTag == Tags.Right.Name
             || existingTag == Tags.Tab.Name )
        {
            return str;
        }

        return tag.Append( str );
    }
}