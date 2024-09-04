namespace SmartyStrings.Tests;

[TestClass]
public sealed class TrimEndTests : Tester
{
    [TestMethod]
    public void WhenValueIsNull_Throw()
    {
        //Arrange
        string value = null!;
        var trimString = Dummy.Create<string>();

        //Act
        var action = () => value.TrimEnd(trimString);

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void WhenTrimStringIsNull_Throw()
    {
        //Arrange
        var value = Dummy.Create<string>();
        string trimString = null!;

        //Act
        Action action = () => value.TrimEnd(trimString);

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void WhenTrimStringIsEmpty_ReturnInitialValue()
    {
        //Arrange
        var value = Dummy.Create<string>();
        var trimString = string.Empty;

        //Act
        var result = value.TrimEnd(trimString);

        //Assert
        result.Should().Be(value);
    }

    [TestMethod]
    public void WhenEndsWithValue_TrimEnd()
    {
        //Arrange
        var value = "J'ai mangé une raie de sayabec à montréal";

        //Act
        var result = value.TrimEnd(" à montréal");

        //Assert
        result.Should().BeEquivalentTo("J'ai mangé une raie de sayabec");
    }

    [TestMethod]
    public void WhenEndsWithValueWithDifferentCasing_DoNotTrim()
    {
        //Arrange
        var value = "J'ai mangé une raie de sayabec à montréal";

        //Act
        var result = value.TrimEnd(" à Montréal");

        //Assert
        result.Should().BeEquivalentTo(value);
    }

    [TestMethod]
    public void WhenEndsWithValueWithDifferentCasingAndIgnoreCase_TrimEnd()
    {
        //Arrange
        var value = "J'ai mangé une raie de sayabec à montréal";

        //Act
        var result = value.TrimEnd(" à Montréal", StringComparison.InvariantCultureIgnoreCase);

        //Assert
        result.Should().BeEquivalentTo("J'ai mangé une raie de sayabec");
    }

    [TestMethod]
    public void WhenFixtureEndsWithValue_TrimEnd()
    {
        //Arrange
        var startPart = Dummy.Create<string>();
        var endpart = Dummy.Create<string>();

        var value = startPart + endpart;

        //Act
        var result = value.TrimEnd(endpart);

        //Assert
        result.Should().BeEquivalentTo(startPart);
    }

    [TestMethod]
    public void WhenFixtureDoesNotEndWithValue_DoNotTrim()
    {
        //Arrange
        var startPart = Dummy.Create<string>();
        var endpart = Dummy.Create<string>();

        var value = startPart + endpart;

        //Act
        var result = value.TrimEnd(startPart);

        //Assert
        result.Should().BeEquivalentTo(value);
    }

    [TestMethod]
    public void WhenValueIsLargerThanString_DoNotTrimAnything()
    {
        //Arrange
        var startPart = Dummy.Create<string>();
        var endpart = Dummy.Create<string>() + Dummy.Create<string>();

        var value = startPart + endpart;

        //Act
        var result = value.TrimEnd(startPart);

        //Assert
        result.Should().BeEquivalentTo(value);
    }

    [TestMethod]
    public void WhenRepeatsAtEnd_TrimAllRepeats()
    {
        //Arrange
        var value = "Montréal est rectalcacacacacaca";

        //Act
        var result = value.TrimEnd("caca");

        //Assert
        result.Should().BeEquivalentTo("Montréal est rectal");
    }
}