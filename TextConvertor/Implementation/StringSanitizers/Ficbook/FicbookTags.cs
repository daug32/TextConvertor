using System.Text.RegularExpressions;

namespace TextConvertor.Implementation.StringSanitizers.Ficbook;

public static class FicbookTags
{
    public static readonly FicbookTag Tab = new( "tab", isCompound: false );
    public static readonly FicbookTag Italic = new( "i" );
    public static readonly FicbookTag Bold = new( "b" );
    public static readonly FicbookTag Stroked = new( "s" );
    public static readonly FicbookTag Center = new( "center" );
    public static readonly FicbookTag Right = new( "right" );
}

public class FicbookTag
{
    public string Name { get; init; }
    public bool IsCompound { get; init; }

    public FicbookTag( string name, bool isCompound = true )
    {
        Name = name;
        IsCompound = isCompound;
    }

    public string Append( string str )
    {
        return IsCompound
            ? $"<{Name}>{str}</{Name}>"
            : $"<{Name}>{str}";
    }
}