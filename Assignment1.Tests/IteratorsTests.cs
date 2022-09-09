namespace Assignment1.Tests;


public class IteratorsTests
{

    [Fact]
    public void Flatten_streams_1_2_and_3_4_return_strea_1_2_3_4()
    {
        // Given
        var stream1 = new int[]{1,2};
        var stream2 = new int[]{3,4};
        var streamMix = new int[][]{stream1, stream2};
        // When
        var flattenStream = Iterators.Flatten(streamMix);

        // Then
        Assert.Equal(new int[]{1,2,3,4}, flattenStream);
    }
}