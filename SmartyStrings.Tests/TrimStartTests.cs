namespace SmartyStrings.Tests;

[TestClass]
public sealed class TrimStartTests : Tester
{
    [TestMethod]
    public void WhenValueIsNull_Throw()
    {
        //Arrange
        string value = null!;
        var trimString = Dummy.Create<string>();

        //Act
        Action action = () => value.TrimStart(trimString);

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
        Action action = () => value.TrimStart(trimString);

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
        var result = value.TrimStart(trimString);

        //Assert
        result.Should().Be(value);
    }

    [TestMethod]
    public void WhenStartsWith_TrimStart()
    {
        //Arrange
        var value = "Montréal est un patapon";

        //Act
        var result = value.TrimStart("Mont");

        //Assert
        result.Should().BeEquivalentTo("réal est un patapon");
    }

    [TestMethod]
    public void WhenStartsWithWithDifferentCasing_DoNotTrim()
    {
        //Arrange
        var value = "Montréal est un patapon";

        //Act
        var result = value.TrimStart("mont");

        //Assert
        result.Should().BeEquivalentTo(value);
    }

    [TestMethod]
    public void WhenStartsWithWithDifferentCasingButIgnoreCase_TrimStart()
    {
        //Arrange
        var value = "Montréal est un patapon";

        //Act
        var result = value.TrimStart("mont", StringComparison.InvariantCultureIgnoreCase);

        //Assert
        result.Should().BeEquivalentTo("réal est un patapon");
    }

    [TestMethod]
    public void WhenStartsWithWithDifferentCasingButIgnoreCaseMultipleOccurences_TrimStart()
    {
        //Arrange
        var value = "MontMontMontmontréal est un patapon";

        //Act
        var result = value.TrimStart("mont", StringComparison.InvariantCultureIgnoreCase);

        //Assert
        result.Should().BeEquivalentTo("réal est un patapon");
    }
}