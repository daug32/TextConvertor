namespace TextConvertor.Console.Extensions;

public static class StringExtension
{
    public static string RemoveQuotes( this string? str )
    {
        if ( str == null )
        {
            throw new NullReferenceException( nameof( str ) );
        }
        
        string path = str;
        
        if ( path.First() == '\"' )
        {
            path = path.Remove( 0, 1 );
        }

        if ( path.Last() == '\"' )
        {
            path = path.Remove( path.Length - 1, 1 );
        }

        if ( String.IsNullOrWhiteSpace( path ) )
        {
            return String.Empty;
        }
        
        return path;
    }

    public static string Remove( this string str, string toRemove )
    {
        return str.Replace( toRemove, "" );
    }
}