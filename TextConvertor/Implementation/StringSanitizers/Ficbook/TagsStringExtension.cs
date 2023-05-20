using System.Text.RegularExpressions;

namespace TextConvertor.Implementation.StringSanitizers.Ficbook;

public static class TagsStringExtension
{
    public static string AddTag( this string str, FicbookTag tag )
    {
        if ( tag != FicbookTags.Tab )
        {
            return tag.Append( str );
        }

        string regex = @"^\s*\<\s*(\w*)\s*\>";
        Match matches = Regex.Match( str, regex );
        if ( !matches.Success )
        {
            return tag.Append( str );
        }
        
        string existingTag = matches.Groups[ 1 ].Value;

        if ( existingTag == FicbookTags.Center.Name
             || existingTag == FicbookTags.Right.Name
             || existingTag == FicbookTags.Tab.Name )
        {
            return str;
        }

        return tag.Append( str );
    }
}