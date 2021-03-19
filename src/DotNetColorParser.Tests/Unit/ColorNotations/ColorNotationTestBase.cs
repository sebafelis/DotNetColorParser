using System;
using Xunit;

namespace DotNetColorParser.Tests.Unit.ColorNotations
{
    public class ColorNotationTestBase
    {
        protected void ColorNotation_WhenInputStringIsCorrect_ThenIsMachMethod_ReturnTrue<T>(string input) where T : IColorNotation
        {
            //Assign
            var colorNotation = Activator.CreateInstance<T>();

            //Act
            var result = colorNotation.IsMatch(input);

            //Assert
            Assert.True(result);
        }

        protected void ColorNotation_WhenInputStringIsIncorrect_ThenIsMachMethod_ReturnFalse<T>(string input) where T : IColorNotation
        {
            //Assign
            var colorNotation = Activator.CreateInstance<T>();

            //Act
            var result = colorNotation.IsMatch(input);

            //Assert
            Assert.False(result);
        }

        protected void ColorNotation_WhenInputStringIsNull_ThenIsMachMethod_ThrowArgumentNullException<T>() where T : IColorNotation
        {
            //Assign
            var colorNotation = Activator.CreateInstance<T>();

            //Act
            void act() => colorNotation.IsMatch(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        protected void ColorNotation_WhenInputStringIsCorrect_ThenParseMethod_ReturnColor<T>(string input, int outputRed, int outputGreen, int outputBlue, int outputAlpha) where T : IColorNotation
        {
            //Assign
            var colorNotation = Activator.CreateInstance<T>();

            //Act
            var actual = colorNotation.Parse(input);

            //Assert
            Assert.Equal(outputRed, actual.R);
            Assert.Equal(outputGreen, actual.G);
            Assert.Equal(outputBlue, actual.B);
            Assert.Equal(outputAlpha, actual.A);
        }

        protected void ColorNotation_WhenInputStringIsIncorrect_ThenParseMethod_ThrowInvalidColorNotationException<T>(string input) where T : IColorNotation
        {
            //Assign
            var colorNotation = Activator.CreateInstance<T>();

            //Act
            void act() => colorNotation.Parse(input);

            //Assert
            Assert.Throws<InvalidColorNotationException>(act);
        }
    }
}
