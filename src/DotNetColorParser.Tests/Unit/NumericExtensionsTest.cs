using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetColorParser;
using Xunit;

namespace DotNetColorParser.Tests.Unit
{
    public class NumericExtensionsTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1.0471975512, 60)]
        [InlineData(0.5235987755982989, 30)]
        [InlineData(0.7853981634, 45)]
        [InlineData(6.2831853072, 360)]
        [InlineData(3.1415926536, 180)]
        public void RadiansToDegrees_WhenPassValueInRadians_ThenReturnValueInDegrees(double radiusValue, double degreesValue)
        {
            var actual = radiusValue.RadiansToDegrees();

            Assert.Equal(degreesValue, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.5, 180)]
        [InlineData(0.25, 90)]
        [InlineData(0.0833333333333333, 30)]
        [InlineData(1, 360)]
        [InlineData(0.1666666666666667, 60)]
        [InlineData(0.125, 45)]
        public void TurnsToDegrees_WhenPassValueInTurns_ThenReturnValueInDegrees(double turnsValue, double degreesValue)
        {
            var actual = turnsValue.TurnsToDegrees();

            Assert.Equal(degreesValue, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0.9)]
        [InlineData(5, 4.5)]
        [InlineData(10, 9)]
        [InlineData(40, 36)]
        [InlineData(50, 45)]
        [InlineData(100, 90)]
        [InlineData(500, 450)]
        public void GradToDegrees_WhenPassValueInGradients_ThenReturnValueInDegrees(double gradValue, double degreesValue)
        {
            var actual = gradValue.GradToDegrees();

            Assert.Equal(degreesValue, actual);
        }
    }
}
