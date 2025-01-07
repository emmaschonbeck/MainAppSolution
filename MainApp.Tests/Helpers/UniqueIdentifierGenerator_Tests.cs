
using MainApp.Helpers;

namespace MainApp.Tests.Helpers;

public class UniqueIdentifierGenerator_Tests
{
    [Fact]

    public void GenerateShouldReturnStringOfTypeGuid()
    {
        string id = UniqueIdentifierGenerator.Generate();

        Assert.False(string.IsNullOrEmpty(id));

        Assert.True(Guid.TryParse(id, out _));
    }
}
