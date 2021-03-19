using DotNetColorParser.ColorNotations;
using Xunit;

namespace DotNetColorParser.Tests.Unit.ColorNotations
{
    public class KnownColorNameNotationTest : ColorNotationTestBase
    {
        [Theory]
        [ClassData(typeof(ValidKnowColorNameTestData))]
        public void IsMach_WhenInputStringIsCorrect_ReturnTrue(string input)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenIsMachMethod_ReturnTrue<KnownColorNameNotation>(input);
        }

        [Theory]
        [ClassData(typeof(InvalidKnowColorNameTestData))]
        public void IsMach_WhenInputStringIsIncorrect_ReturnFalse(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenIsMachMethod_ReturnFalse<KnownColorNameNotation>(input);
        }

        [Fact]
        public void IsMach_WhenInputStringIsNull_ThrowArgumentNullException()
        {
            ColorNotation_WhenInputStringIsNull_ThenIsMachMethod_ThrowArgumentNullException<KnownColorNameNotation>();
        }

        [Theory]
        [ClassData(typeof(ValidKnowColorNameWithRBGAValueTestData))]
        public void Parse_WhenInputStringIsCorrect_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenParseMethod_ReturnColor<KnownColorNameNotation>(input, outputRed, outputGreen, outputBlue, outputAlpha);
        }

        [Theory]
        [ClassData(typeof(InvalidKnowColorNameTestData))]
        public void Parse_WhenInputStringIsIncorrect_ThrowInvalidColorNotationException(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenParseMethod_ThrowInvalidColorNotationException<KnownColorNameNotation>(input);
        }
    }
}
