using Business.Helpers;

namespace Tests.Helpers;

public class IDGenerators_Tests
{
    [Fact]
    public void Generate_ShouldReturnGuidAsString()
    {
        // act
        var result = IdGenerator.Generate();

        // assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}
