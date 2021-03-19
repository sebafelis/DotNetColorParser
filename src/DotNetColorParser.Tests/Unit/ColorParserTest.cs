using DotNetColorParser.ColorNotations;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;

namespace DotNetColorParser.Tests.Unit
{
    public class ColorParserTest
    {
        [Fact]
        public void ParseColor_WhenInputStringHasSupportedNotaion_ReturnColor()
        {
            string value = "#ffffff";

            //Assign
            IEnumerator<IColorNotation> ColorNotationEnumerator(Color result)
            {
                yield return Mock.Of<IColorNotation>(m => m.IsMatch(value) == false);
                yield return Mock.Of<IColorNotation>(m => m.IsMatch(value) == true && m.Parse(value) == result);
            }

            var expected = Color.Aqua;
            var colorNotation = ColorNotationEnumerator(expected);

            var colorParser = new ColorParser(Mock.Of<IColorNotationProvider>(m => m.GetEnumerator() == colorNotation));

            //Act
            var actual = colorParser.ParseColor(value);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParseColor_WhenInputStringHasUnsupportedNotaion_ThrowUnkownColorNotationException()
        {
            string value = "#ffffff";

            //Assign
            IEnumerator<IColorNotation> ColorNotationEnumerator()
            {
                yield return Mock.Of<IColorNotation>(m => m.IsMatch(value) == false);
                yield return Mock.Of<IColorNotation>(m => m.IsMatch(value) == false);
            }

            var colorNotation = ColorNotationEnumerator();

            var colorParser = new ColorParser(Mock.Of<IColorNotationProvider>(m => m.GetEnumerator() == colorNotation));

            //Act
            Action act = () => colorParser.ParseColor(value);

            //Assert
            Assert.Throws<UnkownColorNotationException>(act);
        }

        [Fact]
        public void ParseColor_WhenInputStringIsNull_ThrowArgumentException()
        {
            //Assign
            var colorParser = new ColorParser(null);

            //Act
            Action act = () => colorParser.ParseColor(null);

            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ParseColor_WhenInputStringIsEmpty_ThrowArgumentException()
        {
            //Assign
            var inputValue = "";
            var colorParser = new ColorParser(null);

            //Act
            Action act = () => colorParser.ParseColor(inputValue);

            //Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
