namespace Assignment1.Tests;


public class IteratorsTests
{

    [Fact]
    public void Flatten_streams_1_2_and_3_4_return_stream_1_2_3_4()
    {
        // Given
        var stream1 = new int[] { 1, 2 };
        var stream2 = new int[] { 3, 4 };
        var streamMix = new int[][] { stream1, stream2 };
        // When
        var flattenStream = Iterators.Flatten(streamMix);

        // Then
        Assert.Equal(new int[] { 1, 2, 3, 4 }, flattenStream);
    }

    [Fact]
    public void Filter_stream_1_2_3_4_return_stream_2_4()
    {
        // Given
        var stream = new int[] { 1, 2, 3, 4 };
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;
        // When
        var result = Iterators.Filter(stream, Even);

        // Then
        Assert.Equal(new int[] { 2, 4 }, result);

    }
}