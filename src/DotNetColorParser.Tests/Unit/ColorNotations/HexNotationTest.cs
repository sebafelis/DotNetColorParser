using DotNetColorParser.ColorNotations;
using Xunit;

namespace DotNetColorParser.Tests.Unit.ColorNotations
{
    public class HexNotationTest : ColorNotationTestBase
    {
        [Theory]
        [ClassData(typeof(ValidHexTestData))]
        public void IsMach_WhenInputStringIsCorrect_ReturnTrue(string input)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenIsMachMethod_ReturnTrue<HexRGBANotation>(input);
        }

        [Theory]
        [ClassData(typeof(InvalidHexTestData))]
        public void IsMach_WhenInputStringIsIncorrect_ReturnFalse(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenIsMachMethod_ReturnFalse<HexRGBANotation>(input);
        }

        [Fact]
        public void IsMach_WhenInputStringIsNull_ThrowArgumentNullException()
        {
            ColorNotation_WhenInputStringIsNull_ThenIsMachMethod_ThrowArgumentNullException<HexRGBANotation>();
        }

        [Theory]
        [ClassData(typeof(ValidHexWithRGBAValueTestData))]
        public void Parse_WhenInputStringIsCorrect_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenParseMethod_ReturnColor<HexRGBANotation>(input, outputRed, outputGreen, outputBlue, outputAlpha);
        }

        [Theory]
        [ClassData(typeof(InvalidHexTestData))]
        public void Parse_WhenInputStringIsIncorrect_ThrowInvalidColorNotationException(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenParseMethod_ThrowInvalidColorNotationException<HexRGBANotation>(input);
        }
    }
}
