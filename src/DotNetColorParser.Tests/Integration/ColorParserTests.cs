using DotNetColorParser.ColorNotations;
using System;
using Xunit;

namespace DotNetColorParser.Tests.Integration
{
    public class ColorParserTests
    {
        [Theory]
        [InlineData("red", 255, 0, 0, 255)]
        [InlineData("#fff", 255, 255, 255, 255)]
        [InlineData("fff", 255, 255, 255, 255)]
        [InlineData("#ffffff", 255, 255, 255, 255)]
        [InlineData("ffffff", 255, 255, 255, 255)]
        [InlineData("rgb(255, 0, 0)", 255, 0, 0, 255)]
        [InlineData("rgb 255 0 0", 255, 0, 0, 255)]
        [InlineData("hsl(0, 100, 50)", 255, 0, 0, 255)]
        [InlineData("hsl(0, 100%, 50%)", 255, 0, 0, 255)]
        [InlineData("hsl 0 100 50", 255, 0, 0, 255)]
        [InlineData("hsl 0 100% 50%", 255, 0, 0, 255)]
        [InlineData("hsv(0, 100%, 100%)", 255, 0, 0, 255)]
        [InlineData("hsv(0, 100, 100)", 255, 0, 0, 255)]
        [InlineData("hsv 0 100% 100%", 255, 0, 0, 255)]
        [InlineData("hsv 0 100 100", 255, 0, 0, 255)]
        public void ColorParserClass_HasNewInstance_WithDefaultProvider_ThenParseColorMethod_WithCorrectInputValue_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            //Assign
            var colorParser = new ColorParser(null);

            //Act
            var actual = colorParser.ParseColor(input);

            //Assert
            Assert.Equal(outputRed, actual.R);
            Assert.Equal(outputGreen, actual.G);
            Assert.Equal(outputBlue, actual.B);
            Assert.Equal(outputAlpha, actual.A);
        }

        [Theory]
        [ClassData(typeof(ValidRGBWithRGBAValueTestData))]
        public void ColorParserClass_UseStaticParseMethod_WithSpecifyOnlyRBGNotation_AndCorrectInputValue_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            //Act
            var actual = ColorParser.Parse<RGBNotation>(input);

            //Assert
            Assert.Equal(outputRed, actual.R);
            Assert.Equal(outputGreen, actual.G);
            Assert.Equal(outputBlue, actual.B);
            Assert.Equal(outputAlpha, actual.A);
        }

        [Theory]
        [InlineData("rgba(255, 0, 0, 0.5%)")]
        [InlineData("hsv(180, 50%, 50%)")]
        [InlineData("hsl(180, 50%, 50%)")]
        [InlineData("#ffffff")]
        public void ColorParserClass_UseStaticParseMethod_WithSpecifyOnlyRBGNotation_AndInputValueIsNotInRGBNotation_ThrowInvalidUnkownColorNotationException(string input)
        {
            //Act
            Action act = () => ColorParser.Parse<RGBNotation>(input);

            //Assert
            Assert.Throws<UnkownColorNotationException>(act);
        }

        
    }
}
