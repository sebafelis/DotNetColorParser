using Moq;
using System;
using Xunit;

namespace DotNetColorParser.Tests.Unit
{
    public class ColorNotationProviderTest
    {
        readonly ColorNotationProvider _colorNotations;
        readonly IColorNotation _colorNotationInstance;

        public ColorNotationProviderTest()
        {
            _colorNotationInstance = GetColorNotationMock(0, 555);
            _colorNotations = new ColorNotationProvider() { _colorNotationInstance };
        }

        public void AddMethod_WithNewNotation_WhenNotationIsNotRegistered_ThenProviderContainsIt()
        {
            //Assign
            var colorNotation = GetColorNotationMock(0, 666);

            //Act
            _colorNotations.Add(colorNotation);

            //Assert
            Assert.Contains(colorNotation, _colorNotations);
        }

        public void AddMethod_WithAlredyRegistredNotation_ThrowArgumentException()
        {
            //Act
            Action act = () => _colorNotations.Add(_colorNotationInstance);

            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        public void AddMethod_WithNull_ThrowArgumentNullException()
        {
            //Act
            Action act = () => _colorNotations.Add(_colorNotationInstance);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        public void RemoveRemove_WithAlredyRegistredNotation_ThenReturnTrue_AndProviderDoesNotContainsItAnymore()
        {
            //Act
            var result = _colorNotations.Remove(_colorNotationInstance);

            //Assert
            Assert.True(result);
            Assert.DoesNotContain(_colorNotationInstance, _colorNotations);
        }

        public void RemoveMethod_WithNotRegistredNotation_ReturnFalse()
        {
            //Assign
            var colorNotation = GetColorNotationMock(0, 666);

            //Act
            var result = _colorNotations.Remove(colorNotation);

            //Assert
            Assert.False(result);
        }

        public void ContainsMethod_WithRegistredNotation_ReturnTrue()
        {
            //Act
            var result = _colorNotations.Contains(_colorNotationInstance);

            //Assert
            Assert.True(result);
        }

        public void ContainsMethod_WithNotRegistredNotation_ReturnFalse()
        {
            //Act
            var result = _colorNotations.Contains(_colorNotationInstance);

            //Assert
            Assert.True(result);
        }

        private IColorNotation GetColorNotationMock(int order, int hashCode)
        {
            return Mock.Of<IColorNotation>(n => n.Order == order && n.GetHashCode() == hashCode);
        }
    }
}
