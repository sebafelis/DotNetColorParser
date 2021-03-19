using DotNetColorParser.ColorNotations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DotNetColorParser.Tests.Unit.ColorNotations
{
    public class HSLANotationTest : ColorNotationTestBase
    {
        [Theory]
        [ClassData(typeof(ValidHSLATestData))]
        public void IsMach_WhenInputStringIsCorrect_ReturnTrue(string input)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenIsMachMethod_ReturnTrue<HSLANotation>(input);
        }

        [Theory]
        [ClassData(typeof(InvalidHSLATestData))]
        public void IsMach_WhenInputStringIsIncorrect_ReturnFalse(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenIsMachMethod_ReturnFalse<HSLANotation>(input);
        }

        [Fact]
        public void IsMach_WhenInputStringIsNull_ThrowArgumentNullException()
        {
            ColorNotation_WhenInputStringIsNull_ThenIsMachMethod_ThrowArgumentNullException<HSLANotation>();
        }

        [Theory]
        [ClassData(typeof(ValidHSLAWithRBGAValueTestData))]
        public void Parse_WhenInputStringIsCorrect_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            ColorNotation_WhenInputStringIsCorrect_ThenParseMethod_ReturnColor<HSLANotation>(input, outputRed, outputGreen, outputBlue, outputAlpha);
        }

        [Theory]
        [ClassData(typeof(InvalidHSLATestData))]
        public void Parse_WhenInputStringIsIncorrect_ThrowInvalidColorNotationException(string input)
        {
            ColorNotation_WhenInputStringIsIncorrect_ThenParseMethod_ThrowInvalidColorNotationException<HSLANotation>(input);
        }
    }
}
