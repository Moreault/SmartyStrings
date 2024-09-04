namespace SmartyStrings.Tests;

[TestClass]
public sealed class LastIndexTests
{
    [TestMethod]
    public void WhenInstanceIsNull_Throw()
    {
        //Arrange
        string instance = null!;

        //Act
        var action = () => instance.LastIndex();

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void WhenInstanceIsEmpty_ReturnMinusOne()
    {
        //Arrange

        //Act
        var result = "".LastIndex();

        //Assert
        result.Should().Be(-1);
    }

    [TestMethod]
    public void WhenInstanceIsABunchOfWhiteSpaces_ReturnLastIndex()
    {
        //Arrange

        //Act
        var result = "   ".LastIndex();

        //Assert
        result.Should().Be(2);
    }

    [TestMethod]
    public void WhenInstanceIsNotNullOrEmptyOrWhiteSpace_ReturnLastIndex()
    {
        //Arrange

        //Act
        var result = "Sébastien".LastIndex();

        //Assert
        result.Should().Be(8);
    }
}