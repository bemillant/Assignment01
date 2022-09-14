namespace Assignment1.Tests;

public class RegExprTests
{


    [Fact]
    public void SplitLine_when_stream_contains_many_sentences_returns_stream_of_individual_words()
    {
        // Given
        var stream = new List<String> { "Hello World", "This is a sentence", "Haha" };
        var streamShouldBe = new List<String> { "Hello", "World", "This", "is", "a", "sentence", "Haha" };
        // When
        var result = RegExpr.SplitLine(stream);
        // Then
        Assert.Equal(streamShouldBe, result);
    }

    [Fact]
    public void Resolutions_when_stream_contains_1920x1080_1024x768_800x600_returns_tuples()
    {
        // Given
        var stream = new List<String> { "1920x1080", "1024x768, 800x600" };
        (int, int) t1 = (1920, 1080);
        (int, int) t2 = (1024, 768);
        (int, int) t3 = (800, 600);
        var streamToBe = new List<(int, int)> { t1, t2, t3 };

        // When
        var result = RegExpr.Resolution(stream);

        // Then
        Assert.Equal(streamToBe, result);
        
    }

    // [Fact]

    // public void InnerText_htmlInnerText_with_tag_a_should_return_stream_of_string()
    // {
    //     // Given

    //     String input = "<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p> </div>";
    //     var streamToBe = new List<String> { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" };


    //     // When
    //     var result = RegExpr.InnerText(input, "a");

    //     // Then
    //     Assert.Equal(streamToBe, result);
    // }
    [Fact]

    public void InnerText_htmlInnerText_with_tag_p_should_return_stream_of_string()
    {
        // Given

        String input = @"<div> <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p> </div>";
        var streamToBe = new List<String> { "theoretical computThe phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." };


        // When
        var result = RegExpr.InnerText(input, "p");

        // Then
        Assert.Equal(streamToBe, result);
    }

    [Fact]
    public void URLTest1() {
        
        var input = @"<div><a href=""https://www.google.com"">innerText</a></div>";
        var input2 = @"<div><a href=""https://www.google.com"" title=""title"">innerText</a></div>";

        IEnumerable<(Uri url, string title)> result1 = RegExpr.Urls(input);
        IEnumerable<(Uri url, string title)> result2 = RegExpr.Urls(input2);

        Assert.Equal(new [] { (new Uri("https://www.google.com"), "innerText")}, result1);
        Assert.Equal(new [] { (new Uri("https://www.google.com"), "title")}, result2);
    }

}