namespace TextConvertor.Core.Sanitizers;

public interface IStringSanitizer
{
    /// <summary>
    ///     Sanitize a single string
    /// </summary>
    string Sanitize( string str );
}