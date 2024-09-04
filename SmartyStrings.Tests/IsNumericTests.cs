namespace SmartyStrings.Tests;

public sealed class IsNumericTests : Tester
{
    [TestMethod]
    public void WhenIsNullValue_ThrowsArgumentNullException()
    {
        // Arrange
        string value = null!;

        // Act
        var action = () => value.IsNumeric();

        // Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    [TestMethod]
    public void WhenIsIntegerValue_ReturnsTrue()
    {
        // Arrange
        var value = Dummy.Create<int>().ToString();

        // Act
        var result = value.IsNumeric();

        // Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void WhenIsNonNumericValue_ReturnsFalse()
    {
        // Arrange
        var value = Dummy.Create<string>();

        // Act
        var result = value.IsNumeric();

        // Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void WhenIsFloat_ReturnTrue()
    {
        //Arrange
        var value = (Dummy.Create<float>() + new Random().NextDouble()).ToString(CultureInfo.InvariantCulture);

        //Act
        var result = value.IsNumeric();

        //Assert
        result.Should().BeTrue();
    }
}