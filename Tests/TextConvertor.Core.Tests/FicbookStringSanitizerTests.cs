using NUnit.Framework;
using TextConvertor.Core.Implementation;
using TextConvertor.Core.Implementation.Models;

namespace TextConvertor.Tests;

public class FicbookStringSanitizerTests
{
    private FicbookStringSanitizer _ficbookStringSanitizer = null!;

    [SetUp]
    public void Setup()
    {
        _ficbookStringSanitizer = new FicbookStringSanitizer();
    }

    [TestCase( "<tab>today is a day when everyone is happy", "  today is a day when everyone    is happy    " )]
    [TestCase( "<center> *** </ center>", "   <center>   *** </ center> " )]
    [TestCase( "< center >***</ center >", "< center >***</ center >" )]
    public void Sanitize_TestWhitespaces( string expected, string input )
    {
        // Act
        string result = _ficbookStringSanitizer.Sanitize( input );

        // Assert
        Assert.AreEqual( expected, result );
    }

    [TestCase( "<tab>face-to-face", "face- to-face" )]
    [TestCase( "<tab>face-to-face", "face -to-face" )]
    [TestCase( "<tab>face - to-face", "face - to-face" )]
    [TestCase( $"<tab>{Symbols.Dash} to-face", "- to-face" )]
    [TestCase( $"<tab>{Symbols.Dash} She is awful!", "- She is awful!" )]
    [TestCase( $"<tab>{Symbols.Dash} And she said, {Symbols.Dash} Aquasha said", "-- And she said, -- Aquasha said" )]
    public void Sanitize_TestHyphens( string expected, string input )
    {
        // Act
        string result = _ficbookStringSanitizer.Sanitize( input );

        // Assert
        Assert.AreEqual( expected, result );
    }

    [TestCase( "<center>***</center>", "***   " )]
    [TestCase( "<center>***</center>", "   ***     " )]
    [TestCase( "<center>***</center>", "***" )]
    [TestCase( "<tab>Something", "<tab>Something" )]
    [TestCase( "<tab><b>Something</b>", "<b>Something</b>" )]
    public void Sanitize_TestTagsReplacements( string expected, string input )
    {
        // Act
        string result = _ficbookStringSanitizer.Sanitize( input );

        // Assert
        Assert.AreEqual( expected, result );
    }
}