using DotNetColorParser.ColorNotations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DotNetColorParser.Tests.Unit.ColorNotations
{
    public class RGBNotationTest : ColorNotationTestBase
    {
        [Theory]
        [ClassData(typeof(ValidRGBTestData))]
        public void IsMach_WhenInputStringIsCorrect_ReturnTrue(string input)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenIsMachMethod_ReturnTrue<RGBNotation>(input);
        }

        [Theory]
        [ClassData(typeof(InvalidRGBTestData))]
        public void IsMach_WhenInputStringIsIncorrect_ReturnFalse(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenIsMachMethod_ReturnFalse<RGBNotation>(input);
        }

        [Fact]
        public void IsMach_WhenInputStringIsNull_ThrowArgumentNullException()
        {
            ColorNotation_WhenInputStringIsNull_ThenIsMachMethod_ThrowArgumentNullException<RGBNotation>();
        }

        [Theory]
        [ClassData(typeof(ValidRGBWithRGBAValueTestData))]
        public void Parse_WhenInputStringIsCorrect_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenParseMethod_ReturnColor<RGBNotation>(input, outputRed, outputGreen, outputBlue, outputAlpha);
        }

        [Theory]
        [ClassData(typeof(InvalidRGBTestData))]
        public void Parse_WhenInputStringIsIncorrect_ThrowInvalidColorNotationException(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenParseMethod_ThrowInvalidColorNotationException<RGBNotation>(input);
        }
    }
}
