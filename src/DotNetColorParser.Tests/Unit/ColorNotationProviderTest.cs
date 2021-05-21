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

        [Fact]
        public void Add_NewNotation_WhenNotationIsNotRegistered_ThenProviderContainsIt()
        {
            //Assign
            var colorNotation = GetColorNotationMock(0, 666);

            //Act
            _colorNotations.Add(colorNotation);

            //Assert
            Assert.Contains(colorNotation, _colorNotations);
        }

        [Fact]
        public void Add_AlredyRegistredNotation_ThrowArgumentException()
        {
            //Act
            Action act = () => _colorNotations.Add(_colorNotationInstance);

            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Add_Null_ThrowArgumentNullException()
        {
            //Act
            Action act = () => _colorNotations.Add(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Remove_AlredyRegistredNotation_ThenReturnTrue_AndProviderDoesNotContainsItAnymore()
        {
            //Act
            var result = _colorNotations.Remove(_colorNotationInstance);

            //Assert
            Assert.True(result);
            Assert.DoesNotContain(_colorNotationInstance, _colorNotations);
        }

        [Fact]
        public void Remove_NotRegistredNotation_ReturnFalse()
        {
            //Assign
            var colorNotation = GetColorNotationMock(0, 666);

            //Act
            var result = _colorNotations.Remove(colorNotation);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Contains_WhenNotationIsRegistred_ReturnTrue()
        {
            //Act
            var result = _colorNotations.Contains(_colorNotationInstance);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Contains_WhenNotationIsNotRegistred_ReturnFalse()
        {
            //Act
            var result = _colorNotations.Contains(_colorNotationInstance);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void GetEnumerator_ReturnCorrectOrder()
        {
            //Arrange
            var colorNotations = new ColorNotationProvider() {
                GetColorNotationMock(0, 555),
                GetColorNotationMock(2, 565),
                GetColorNotationMock(2, 785),
                GetColorNotationMock(3, 805),
                GetColorNotationMock(0, 570)
            };
            var lastOrderValue = 0;

            //Act
            var result = colorNotations.GetEnumerator();

            //Assert
            while (result.MoveNext())
            {
                Assert.True(lastOrderValue <= result.Current.Order, "Order parameter value is less then before order value");
                lastOrderValue = result.Current.Order;
            }
        }

        [Fact]
        public void Clear_ShouldClearCollection()
        {
            //Act
            _colorNotations.Clear();

            //Assert
            Assert.Empty(_colorNotations);
        }

        private IColorNotation GetColorNotationMock(int order, int hashCode)
        {
            return Mock.Of<IColorNotation>(n => n.Order == order && n.GetHashCode() == hashCode);
        }
    }
}
