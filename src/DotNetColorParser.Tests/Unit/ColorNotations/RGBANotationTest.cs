using DotNetColorParser.ColorNotations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DotNetColorParser.Tests.Unit.ColorNotations
{
    public class RGBANotationTest : ColorNotationTestBase
    {
        [Theory]
        [ClassData(typeof(ValidRGBATestData))]
        public void IsMach_WhenInputStringIsCorrect_ReturnTrue(string input)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenIsMachMethod_ReturnTrue<RGBANotation>(input);
        }

        [Theory]
        [ClassData(typeof(InvalidRGBATestData))]
        public void IsMach_WhenInputStringIsIncorrect_ReturnFalse(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenIsMachMethod_ReturnFalse<RGBANotation>(input);
        }

        [Fact]
        public void IsMach_WhenInputStringIsNull_ThrowArgumentNullException()
        {
            ColorNotation_WhenInputStringIsNull_ThenIsMachMethod_ThrowArgumentNullException<RGBANotation>();
        }

        [Theory]
        [ClassData(typeof(ValidRGBAWithRGBAValueTestData))]
        public void Parse_WhenInputStringIsCorrect_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenParseMethod_ReturnColor<RGBANotation>(input, outputRed, outputGreen, outputBlue, outputAlpha);
        }

        [Theory]
        [ClassData(typeof(InvalidRGBATestData))]
        public void Parse_WhenInputStringIsIncorrect_ThrowInvalidColorNotationException(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenParseMethod_ThrowInvalidColorNotationException<RGBANotation>(input);
        }
    }
}
