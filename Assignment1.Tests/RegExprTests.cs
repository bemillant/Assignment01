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

}