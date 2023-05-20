namespace TextConvertor.Implementation.StringSanitizers.Ficbook;

internal record Tag( string Name, bool IsCompound = true )
{
    public string Append( string str )
    {
        return IsCompound
            ? $"<{Name}>{str}</{Name}>"
            : $"<{Name}>{str}";
    }
}