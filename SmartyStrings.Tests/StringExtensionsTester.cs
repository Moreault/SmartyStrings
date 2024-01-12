namespace SmartyStrings.Tests;

[TestClass]
public class StringExtensionsTester
{
    [TestClass]
    public class RemoveAll_String : Tester
    {
        [TestMethod]
        public void WhenValueIsNull_Throw()
        {
            // Arrange
            string value = null!;
            var toRemove = Fixture.Create<string>();

            // Act
            var action = () => value.RemoveAll(toRemove);

            // Assert
            action.Should().Throw<ArgumentNullException>().WithParameterName("value");
        }

        [TestMethod]
        public void RemoveAll_ShouldRemoveAllOccurrences_WhenValueIsNotNull()
        {
            // Arrange
            var toRemove = Fixture.Create<string>();
            var otherStuff = Fixture.Create<string>();
            var value = $"{toRemove}{toRemove}{otherStuff}{toRemove}";

            // Act
            var result = value.RemoveAll(toRemove);

            // Assert
            result.Should().Be(otherStuff);
        }
    }

    [TestClass]
    public class RemoveAll_Char : Tester
    {
        [TestMethod]
        public void WhenValueIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            string value = null!;
            var toRemove = Fixture.Create<char>();

            // Act
            var action = () => value.RemoveAll(toRemove);

            // Assert
            action.Should().Throw<ArgumentNullException>().WithMessage("*value*");
        }

        [TestMethod]
        public void WhenValueIsNotNullAndContainsChar_RemovesAllOccurrencesOfChar()
        {
            // Arrange
            var toRemove = Fixture.Create<char>();
            var part1 = Fixture.Create<string>().Replace(toRemove, Fixture.Create<char>());
            var part2 = Fixture.Create<string>().Replace(toRemove, Fixture.Create<char>());
            var value = $"{part1}{toRemove}{part2}{toRemove}";

            // Act
            var result = value.RemoveAll(toRemove);

            // Assert
            result.Should().Be($"{part1}{part2}");
        }

        [TestMethod]
        public void WhenValueIsNotNullAndDoesNotContainChar_ReturnsOriginalString()
        {
            // Arrange
            var toRemove = Fixture.Create<char>();
            var value = Fixture.Create<string>().Replace(toRemove, Fixture.Create<char>());

            // Act
            var result = value.RemoveAll(toRemove);

            // Assert
            result.Should().Be(value);
        }
    }

    [TestClass]
    public class IsNumeric : Tester
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
            var value = Fixture.Create<int>().ToString();

            // Act
            var result = value.IsNumeric();

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenIsNonNumericValue_ReturnsFalse()
        {
            // Arrange
            var value = Fixture.Create<string>();

            // Act
            var result = value.IsNumeric();

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenIsFloat_ReturnTrue()
        {
            //Arrange
            var value = (Fixture.Create<float>() + new Random().NextDouble()).ToString(CultureInfo.InvariantCulture);

            //Act
            var result = value.IsNumeric();

            //Assert
            result.Should().BeTrue();
        }
    }

    [TestClass]
    public class TrimEnd : Tester
    {
        [TestMethod]
        public void WhenValueIsNull_Throw()
        {
            //Arrange
            string value = null!;
            var trimString = Fixture.Create<string>();

            //Act
            var action = () => value.TrimEnd(trimString);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenTrimStringIsNull_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();
            string trimString = null!;

            //Act
            Action action = () => value.TrimEnd(trimString);

            //Assert
            action.Should().Throw<ArgumentNullException>();
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
            var startPart = Fixture.Create<string>();
            var endpart = Fixture.Create<string>();

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
            var startPart = Fixture.Create<string>();
            var endpart = Fixture.Create<string>();

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
            var startPart = Fixture.Create<string>();
            var endpart = Fixture.Create<string>() + Fixture.Create<string>();

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

    [TestClass]
    public class TrimStart : Tester
    {
        [TestMethod]
        public void WhenValueIsNull_Throw()
        {
            //Arrange
            string value = null!;
            var trimString = Fixture.Create<string>();

            //Act
            Action action = () => value.TrimStart(trimString);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenTrimStringIsNull_Throw()
        {
            //Arrange
            var value = Fixture.Create<string>();
            string trimString = null!;

            //Act
            Action action = () => value.TrimStart(trimString);

            //Assert
            action.Should().Throw<ArgumentNullException>();
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

    [TestClass]
    public class IndexesOf : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenInstanceIsEmpty_Throw(string instance)
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            Action action = () => instance.IndexesOf(value);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void WhenValueIsNullOrEmpty_Throw(string value)
        {
            //Arrange
            var instance = Fixture.Create<string>();

            //Act
            Action action = () => instance.IndexesOf(value);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenValueIsWhiteSpace_DoNotThrow()
        {
            //Arrange
            var instance = Fixture.Create<string>();

            //Act
            Action action = () => instance.IndexesOf(" ");

            //Assert
            action.Should().NotThrow();
        }

        [TestMethod]
        public void Always_ReturnAllIndexesOfSubstringInString()
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
        public void WhenFirstCharacterIsAsked_StillReturn()
        {
            //Arrange
            var instance = "Seb is going to the party with Seb";
            var value = "S";

            //Act
            var result = instance.IndexesOf(value);

            //Assert
            result.Should().BeEquivalentTo(new List<int> { 0, 31 });
        }
    }

    [TestClass]
    public class IndexesOf_Char : Tester
    {
        [TestMethod]
        public void WhenIsNullInstance_ShouldThrowArgumentNullException()
        {
            // Arrange
            string instance = null!;
            var value = Fixture.Create<char>();

            // Act
            var action = () => instance.IndexesOf(value);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow('a', 2, 6, 16, 24, 26, 39)]
        [DataRow('u', 11)]
        [DataRow(' ', 4, 10, 14, 19, 22, 30, 32)]
        public void When_ShouldReturnCorrectIndexes(char value, params int[] expected)
        {
            // Arrange
            var instance = "J'ai mangé une raie de sayabec à montréal";

            // Act
            var result = instance.IndexesOf(value);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }


    }

    [TestClass]
    public class LastIndex : Tester
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
}