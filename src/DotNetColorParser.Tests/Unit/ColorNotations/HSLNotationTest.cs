using DotNetColorParser.ColorNotations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DotNetColorParser.Tests.Unit.ColorNotations
{
    public class HSLNotationTest : ColorNotationTestBase
    {
        [Theory]
        [ClassData(typeof(ValidHSLTestData))]
        public void IsMach_WhenInputStringIsCorrect_ReturnTrue(string input)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenIsMachMethod_ReturnTrue<HSLNotation>(input);
        }

        [Theory]
        [ClassData(typeof(InvalidHSLTestData))]
        public void IsMach_WhenInputStringIsIncorrect_ReturnFalse(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenIsMachMethod_ReturnFalse<HSLNotation>(input);
        }

        [Fact]
        public void IsMach_WhenInputStringIsNull_ThrowArgumentNullException()
        {
            ColorNotation_WhenInputStringIsNull_ThenIsMachMethod_ThrowArgumentNullException<HSLNotation>();
        }

        [Theory]
        [ClassData(typeof(ValidHSLWithRGBAValueTestData))]
        public void Parse_WhenInputStringIsCorrect_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenParseMethod_ReturnColor<HSLNotation>(input, outputRed, outputGreen, outputBlue, outputAlpha);
        }

        [Theory]
        [ClassData(typeof(InvalidHSLTestData))]
        public void Parse_WhenInputStringIsIncorrect_ThrowInvalidColorNotationException(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenParseMethod_ThrowInvalidColorNotationException<HSLNotation>(input);
        }
    }
}
