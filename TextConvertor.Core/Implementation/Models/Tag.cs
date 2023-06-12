namespace TextConvertor.Core.Implementation.Models;

internal record Tag( string Name, bool IsCompound = true )
{
    public string Append( string str )
    {
        return IsCompound
            ? $"<{Name}>{str}</{Name}>"
            : $"<{Name}>{str}";
    }
}