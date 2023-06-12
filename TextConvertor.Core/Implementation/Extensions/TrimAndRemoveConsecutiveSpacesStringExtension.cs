using System.Text;

namespace TextConvertor.Core.Implementation.Extensions;

internal static class TrimAndRemoveConsecutiveSpacesStringExtension
{
    private static readonly char _space = ' ';

    public static string TrimAndRemoveConsecutiveSpaces( this string str )
    {
        var stringBuilder = new StringBuilder( str.Length );

        var isSpacePrevious = false;
        foreach ( char symbol in str )
        {
            if ( Char.IsWhiteSpace( symbol ) )
            {
                isSpacePrevious = true;
                continue;
            }

            // We need to solve this situation: "    a"
            bool hasLetters = stringBuilder.Length > 0;
            if ( isSpacePrevious && hasLetters )
            {
                stringBuilder.Append( _space );
            }

            stringBuilder.Append( symbol );
            isSpacePrevious = false;
        }

        return stringBuilder.ToString();
    }
}