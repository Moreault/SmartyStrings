namespace SmartyStrings.Tests;

[TestClass]
public sealed class RemoveAllTests : Tester
{
    [TestMethod]
    public void WithString_WhenValueIsNull_Throw()
    {
        // Arrange
        string value = null!;
        var toRemove = Dummy.Create<string>();

        // Act
        var action = () => value.RemoveAll(toRemove);

        // Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    [TestMethod]
    public void WithString_ShouldRemoveAllOccurrences_WhenValueIsNotNull()
    {
        // Arrange
        var toRemove = Dummy.Create<string>();
        var otherStuff = Dummy.Create<string>();
        var value = $"{toRemove}{toRemove}{otherStuff}{toRemove}";

        // Act
        var result = value.RemoveAll(toRemove);

        // Assert
        result.Should().Be(otherStuff);
    }

    [TestMethod]
    public void WithChar_WhenValueIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        string value = null!;
        var toRemove = Dummy.Create<char>();

        // Act
        var action = () => value.RemoveAll(toRemove);

        // Assert
        action.Should().Throw<ArgumentNullException>().WithMessage("*value*");
    }

    [TestMethod]
    public void WithChar_WhenValueIsNotNullAndContainsChar_RemovesAllOccurrencesOfChar()
    {
        // Arrange
        var toRemove = Dummy.Create<char>();
        var part1 = Dummy.Create<string>().Replace(toRemove, Dummy.Create<char>());
        var part2 = Dummy.Create<string>().Replace(toRemove, Dummy.Create<char>());
        var value = $"{part1}{toRemove}{part2}{toRemove}";

        // Act
        var result = value.RemoveAll(toRemove);

        // Assert
        result.Should().Be($"{part1}{part2}");
    }

    [TestMethod]
    public void WithChar_WhenValueIsNotNullAndDoesNotContainChar_ReturnsOriginalString()
    {
        // Arrange
        var toRemove = Dummy.Create<char>();
        var value = Dummy.Create<string>().Replace(toRemove, Dummy.Create<char>());

        // Act
        var result = value.RemoveAll(toRemove);

        // Assert
        result.Should().Be(value);
    }
}