using DotNetColorParser.ColorNotations;
using DotNetColorParser.Exceptions;
using System;
using System.Drawing;
using Xunit;

namespace DotNetColorParser.Tests.Acceptable
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
        public void ParseColorMethod_WithCorrectInputValue_ReturnColor_WhenColorParserClass_HasNewInstance_WithDefaultProvider(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            //Assign
            var colorParser = new ColorParser(new ColorNotationProvider(true));

            //Act
            var actual = colorParser.ParseColor(input);

            //Assert
            Assert.Equal(outputRed, actual.R);
            Assert.Equal(outputGreen, actual.G);
            Assert.Equal(outputBlue, actual.B);
            Assert.Equal(outputAlpha, actual.A);
        }

        [Theory]
        [InlineData("redy")]
        [InlineData("#fff-")]
        [InlineData("fffx")]
        [InlineData("#ffffff3")]
        [InlineData("fffff")]
        [InlineData("rgb(256, 0, 0)")]
        [InlineData("rgb 256 0 0")]
        [InlineData("hsl(0, 101, 50)")]
        [InlineData("hsl(0, 100%, 101%)")]
        [InlineData("hsl 0 101 50")]
        [InlineData("hsl 0 100% 101%")]
        [InlineData("hsv(0, 101%, 100%)")]
        [InlineData("hsv(0, 101, 100)")]
        [InlineData("hsv 0 101% 100%")]
        [InlineData("hsv 0 100 101")]
        public void ParseColorMethod_WithIncorrectInputValue_ThrowUnkownColorNotationException(string input)
        {
            //Assign
            var colorParser = new ColorParser(new ColorNotationProvider(true));

            //Act
            void act() => colorParser.ParseColor(input);

            //Assert
            Assert.Throws<UnkownColorNotationException>(act);
        }

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
        public void TryParseColorMethod_WithCorrectInputValue_ReturnTrueAndOutputColor_WhenColorParserClass_HasNewInstance_WithDefaultProvider(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            //Assign
            var colorParser = new ColorParser(new ColorNotationProvider(true));

            //Act
            var actual = colorParser.TryParseColor(input, out Color color);

            //Assert
            Assert.True(actual);
            Assert.Equal(outputRed, color.R);
            Assert.Equal(outputGreen, color.G);
            Assert.Equal(outputBlue, color.B);
            Assert.Equal(outputAlpha, color.A);
        }

        [Theory]
        [InlineData("redy")]
        [InlineData("#fff-")]
        [InlineData("fffx")]
        [InlineData("#ffffff3")]
        [InlineData("fffff")]
        [InlineData("rgb(256, 0, 0)")]
        [InlineData("rgb 256 0 0")]
        [InlineData("hsl(0, 101, 50)")]
        [InlineData("hsl(0, 100%, 101%)")]
        [InlineData("hsl 0 101 50")]
        [InlineData("hsl 0 100% 101%")]
        [InlineData("hsv(0, 101%, 100%)")]
        [InlineData("hsv(0, 101, 100)")]
        [InlineData("hsv 0 101% 100%")]
        [InlineData("hsv 0 100 101")]
        public void TryParseColorMethod_WithIncorrectInputValue_ThrowUnkownColorNotationException(string input)
        {
            //Assign
            var colorParser = new ColorParser(new ColorNotationProvider(true));

            //Act
            var actual = colorParser.TryParseColor(input, out Color color);

            //Assert
            Assert.False(actual);
            Assert.Equal(Color.Empty, color);
        }

        [Theory]
        [ClassData(typeof(ValidRGBWithRGBAValueTestData))]
        public void StaticParseMethod_WithSpecifyOnlyRBGNotation_AndCorrectInputValue_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
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
        [ClassData(typeof(ValidRGBWithRGBAValueTestData))]
        public void StaticTryParseMethod_WithSpecifyOnlyRBGNotation_AndCorrectInputValue_ReturnColor(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha)
        {
            //Act
            var actual = ColorParser.TryParse<RGBNotation>(input, out Color color);

            //Assert
            Assert.True(actual);
            Assert.Equal(outputRed, color.R);
            Assert.Equal(outputGreen, color.G);
            Assert.Equal(outputBlue, color.B);
            Assert.Equal(outputAlpha, color.A);
        }

        [Theory]
        [InlineData("rgba(255, 0, 0, 0.5%)")]
        [InlineData("hsv(180, 50%, 50%)")]
        [InlineData("hsl(180, 50%, 50%)")]
        [InlineData("#ffffff")]
        public void StaticParseMethod_WithSpecifyOnlyRBGNotation_WhenInputValueIsNotInRGBNotation_ThrowInvalidUnkownColorNotationException(string input)
        {
            //Act
            void act() => ColorParser.Parse<RGBNotation>(input);

            //Assert
            Assert.Throws<UnkownColorNotationException>(act);
        }

        [Theory]
        [InlineData("rgba(255, 0, 0, 0.5%)")]
        [InlineData("hsv(180, 50%, 50%)")]
        [InlineData("hsl(180, 50%, 50%)")]
        [InlineData("#ffffff")]
        public void StaticTryParseMethod_WithSpecifyOnlyRBGNotation_WhenInputValueIsNotInRGBNotation_ReturnFalse(string input)
        {
            //Act
            var actual = ColorParser.TryParse<RGBNotation>(input, out Color color);

            //Assert
            Assert.False(actual);
            Assert.Equal(Color.Empty, color);
        }


    }
}
