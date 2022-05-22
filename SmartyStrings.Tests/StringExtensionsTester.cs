using ToolBX.SmartyStrings;

namespace SmartyStrings.Tests;

[TestClass]
public class StringExtensionsTester
{
    [TestClass]
    public class RemoveAll_String : Tester
    {
        //TODO Test
    }

    [TestClass]
    public class RemoveAll_Char : Tester
    {
        //TODO Test
    }

    [TestClass]
    public class IsNumeric : Tester
    {
        //TODO Test
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
            var value = "J'ai mang� une raie de sayabec � montr�al";

            //Act
            var result = value.TrimEnd(" � montr�al");

            //Assert
            result.Should().BeEquivalentTo("J'ai mang� une raie de sayabec");
        }

        [TestMethod]
        public void WhenEndsWithValueWithDifferentCasing_DoNotTrim()
        {
            //Arrange
            var value = "J'ai mang� une raie de sayabec � montr�al";

            //Act
            var result = value.TrimEnd(" � Montr�al");

            //Assert
            result.Should().BeEquivalentTo(value);
        }

        [TestMethod]
        public void WhenEndsWithValueWithDifferentCasingAndIgnoreCase_TrimEnd()
        {
            //Arrange
            var value = "J'ai mang� une raie de sayabec � montr�al";

            //Act
            var result = value.TrimEnd(" � Montr�al", StringComparison.InvariantCultureIgnoreCase);

            //Assert
            result.Should().BeEquivalentTo("J'ai mang� une raie de sayabec");
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
            var value = "Montr�al est rectalcacacacacaca";

            //Act
            var result = value.TrimEnd("caca");

            //Assert
            result.Should().BeEquivalentTo("Montr�al est rectal");
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
            var value = "Montr�al est un patapon";

            //Act
            var result = value.TrimStart("Mont");

            //Assert
            result.Should().BeEquivalentTo("r�al est un patapon");
        }

        [TestMethod]
        public void WhenStartsWithWithDifferentCasing_DoNotTrim()
        {
            //Arrange
            var value = "Montr�al est un patapon";

            //Act
            var result = value.TrimStart("mont");

            //Assert
            result.Should().BeEquivalentTo(value);
        }

        [TestMethod]
        public void WhenStartsWithWithDifferentCasingButIgnoreCase_TrimStart()
        {
            //Arrange
            var value = "Montr�al est un patapon";

            //Act
            var result = value.TrimStart("mont", StringComparison.InvariantCultureIgnoreCase);

            //Assert
            result.Should().BeEquivalentTo("r�al est un patapon");
        }

        [TestMethod]
        public void WhenStartsWithWithDifferentCasingButIgnoreCaseMultipleOccurences_TrimStart()
        {
            //Arrange
            var value = "MontMontMontmontr�al est un patapon";

            //Act
            var result = value.TrimStart("mont", StringComparison.InvariantCultureIgnoreCase);

            //Assert
            result.Should().BeEquivalentTo("r�al est un patapon");
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
}