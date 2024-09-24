namespace SmartyStrings.Tests;

[TestClass]
public sealed class IndexesOfTests : Tester
{
    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void WithString_WhenInstanceIsEmpty_Throw(string instance)
    {
        //Arrange
        var value = Dummy.Create<string>();

        //Act
        Action action = () => instance.IndexesOf(value);

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(null)]
    public void WithString_WhenValueIsNullOrEmpty_Throw(string value)
    {
        //Arrange
        var instance = Dummy.Create<string>();

        //Act
        Action action = () => instance.IndexesOf(value);

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void WithString_WhenValueIsWhiteSpace_DoNotThrow()
    {
        //Arrange
        var instance = Dummy.Create<string>();

        //Act
        Action action = () => instance.IndexesOf(" ");

        //Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void WithString_Always_ReturnAllIndexesOfSubstringInString()
    {
        //Arrange
        var instance = "Seb is going to the party with Seb";
        var value = "e";

        //Act
        var result = instance.IndexesOf(value);

        //Assert
        result.Should().BeEquivalentTo(new List<int> { 1, 18, 32 });
    }

    [TestMethod]
    public void WithString_WhenFirstCharacterIsAsked_StillReturn()
    {
        //Arrange
        var instance = "Seb is going to the party with Seb";
        var value = "S";

        //Act
        var result = instance.IndexesOf(value);

        //Assert
        result.Should().BeEquivalentTo(new List<int> { 0, 31 });
    }

    [TestMethod]
    public void WithChar_WhenIsNullInstance_ShouldThrowArgumentNullException()
    {
        // Arrange
        string instance = null!;
        var value = Dummy.Create<char>();

        // Act
        var action = () => instance.IndexesOf(value);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    [DataRow('a', 2, 6, 16, 24, 26, 39)]
    [DataRow('u', 11)]
    [DataRow(' ', 4, 10, 14, 19, 22, 30, 32)]
    public void WithChar_When_ShouldReturnCorrectIndexes(char value, params int[] expected)
    {
        // Arrange
        var instance = "J'ai mangé une raie de sayabec à montréal";

        // Act
        var result = instance.IndexesOf(value);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}