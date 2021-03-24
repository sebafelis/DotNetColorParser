using System;
using System.Drawing;
using Xunit;

namespace DotNetColorParser.Tests.Unit
{
    public class ColorConverterTest
    {
        [Theory]
        [InlineData("#FF0090", 255, 0, 144, 255)]
        [InlineData("#ff0090", 255, 0, 144, 255)]
        [InlineData("ff0090", 255, 0, 144, 255)]
        [InlineData("#ff0090 ", 255, 0, 144, 255)]
        [InlineData("#FFFFFF", 255, 255, 255, 255)]
        [InlineData(" #FFFFFF ", 255, 255, 255, 255)]
        [InlineData("#000000", 0, 0, 0, 255)]
        [InlineData(" #000000", 0, 0, 0, 255)]
        [InlineData("#FFF", 255, 255, 255, 255)]
        [InlineData("#fff", 255, 255, 255, 255)]
        [InlineData("#000", 0, 0, 0, 255)]
        [InlineData("#666", 102, 102, 102, 255)]
        [InlineData("666", 102, 102, 102, 255)]
        [InlineData(" 666", 102, 102, 102, 255)]
        [InlineData("#66aa66bb", 102, 170, 102, 187)]
        [InlineData("#66aa66FF", 102, 170, 102, 255)]
        [InlineData("#66aa6600", 102, 170, 102, 0)]
        public void FromHex_WhenInputValueCorrect_ReturnCorrectColor(string value, int r, int g, int b, int a)
        {
            //Act
            var color = ColorConverter.FromHex(value);

            // Assert
            Assert.Equal(r, color.R);
            Assert.Equal(g, color.G);
            Assert.Equal(b, color.B);
            Assert.Equal(a, color.A);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("#")]
        [InlineData("#fffffg")]
        [InlineData("forsa")]
        [InlineData(null)]
        public void FromHex_WhenInputValueIsIncorrect_ThrowArgumentException(string value)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() => ColorConverter.FromHex(value));
        }

        [Theory]
        [InlineData(100, 25, 0, 0, 0, 191, 255)]
        [InlineData(0, 0, 0, 0, 255, 255, 255)]
        [InlineData(0, 0, 0, 100, 0, 0, 0)]
        [InlineData(100, 0, 100, 0, 0, 255, 0)]
        [InlineData(0, 0, 0, 50, 128, 128, 128)]
        [InlineData(64, 7, 0, 73, 25, 64, 69)]
        [InlineData(0, 77, 45, 14, 219, 50, 121)]
        public void FromCMYK_WhenInputValuesCorrect_ReturnCorrectColor(double c, double m, double y, double k, int r, int g, int b)
        {
            //Act
            var color = ColorConverter.FromCMYK(c, m, y, k);

            // Assert
            Assert.Equal(Color.FromArgb(r, g, b), color);
        }

        [Theory]
        [InlineData(100, 100, 100, 101)]
        [InlineData(100, 100, 101, 100)]
        [InlineData(100, 101, 100, 100)]
        [InlineData(101, 100, 100, 100)]
        [InlineData(0, 0, 0, -1)]
        [InlineData(0, 0, -1, 0)]
        [InlineData(0, -1, 0, 0)]
        [InlineData(-1, 0, 0, 0)]
        [InlineData(-230, -2, -20, -23)]
        [InlineData(230, 101, 120, 123)]
        public void FromCMYK_WhenPassWrongValues_ReturnThrowException(double c, double m, double y, double k)
        {
            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ColorConverter.FromCMYK(c, m, y, k));
        }

        [Theory]
        [InlineData(335, 71, 53, 0, 220, 50, 121, 0)]
        [InlineData(335, 71, 53, 1, 220, 50, 121, 255)]
        [InlineData(335, 71, 53, 0.5, 220, 50, 121, 128)]
        [InlineData(335, 71, 53, 0.2, 220, 50, 121, 51)]
        public void FromHSLA_WhenInputValuesCorrect_ReturnCorrectColor(double h, double s, double l, double a, int r, int g, int b, int oa)
        {
            //Act
            var color = ColorConverter.FromHSLA(h, s, l, a);

            // Assert
            Assert.Equal(Color.FromArgb(oa, r, g, b), color);
        }

        [Theory]
        [InlineData(360, 71, 53, -1)]
        [InlineData(335, 71, 53, 1.2)]
        [InlineData(335, 71, 53, -0.1)]
        [InlineData(335, 71, 53, 100)]
        [InlineData(335, 71, 53, -20)]
        public void FromHSLA_WhenInputValueIsOutOfRange_ThrowOutOfRangeArgumentException(double h, double s, double l, double a)
        {
            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ColorConverter.FromHSLA(h, s, l, a));
        }

        [Theory]
        [InlineData(360, 0, 0, 0, 0, 0)]
        [InlineData(360, 71, 53, 220, 50, 50)]
        [InlineData(335, 71, 53, 220, 50, 121)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(0, 100, 100, 255, 255, 255)]
        [InlineData(0, 100, 0, 0, 0, 0)]
        [InlineData(0, 0, 100, 255, 255, 255)]
        [InlineData(180, 0, 100, 255, 255, 255)]
        [InlineData(180, 0, 50, 128, 128, 128)]
        [InlineData(180, 50, 50, 64, 191, 191)]
        [InlineData(80, 50, 50, 149, 191, 64)]
        [InlineData(20, 60, 50, 204, 102, 51)]
        public void FromHSL_WhenInputValuesCorrect_ReturnCorrectColor(double h, double s, double l, int r, int g, int b)
        {
            //Act
            var color = ColorConverter.FromHSL(h, s, l);

            // Assert
            Assert.Equal(Color.FromArgb(r, g, b), color);
        }

        [Theory]
        [InlineData(360.1, 71, 53)]
        [InlineData(370, 71, 53)]
        [InlineData(-1, 71, 53)]
        [InlineData(-100, 71, 53)]
        [InlineData(0, 100.1, 53)]
        [InlineData(0, 101, 53)]
        [InlineData(0, -1, 53)]
        [InlineData(0, -0.111, 53)]
        [InlineData(0, 50, 100.1)]
        [InlineData(0, 50, 101)]
        [InlineData(0, 50, -1)]
        [InlineData(0, 50, -0.111)]
        public void FromHSL_WhenInputValueIsOutOfRange_ThrowOutOfRangeArgumentException(double h, double s, double l)
        {
            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ColorConverter.FromHSL(h, s, l));
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(0, 100, 0, 0, 0, 0)]
        [InlineData(0, 100, 100, 255, 0, 0)]
        [InlineData(0, 0, 100, 255, 255, 255)]
        [InlineData(180, 100, 100, 0, 255, 255)]
        [InlineData(180, 50, 100, 128, 255, 255)]
        [InlineData(180, 50, 50, 64, 128, 128)]
        [InlineData(90, 50, 50, 96, 128, 64)]
        [InlineData(33.333, 100, 100, 255, 142, 0)]
        public void FromHSV_WhenInputValuesCorrect_ReturnCorrectColor(double h, double s, double v, int r, int g, int b)
        {
            //Act
            var color = ColorConverter.FromHSV(h, s, v);

            // Assert
            Assert.Equal(Color.FromArgb(r, g, b), color);
        }

        [Theory]
        [InlineData(360.1, 71, 53)]
        [InlineData(370, 71, 53)]
        [InlineData(-1, 71, 53)]
        [InlineData(-100, 71, 53)]
        [InlineData(0, 100.1, 53)]
        [InlineData(0, 101, 53)]
        [InlineData(0, -1, 53)]
        [InlineData(0, -0.111, 53)]
        [InlineData(0, 50, 100.1)]
        [InlineData(0, 50, 101)]
        [InlineData(0, 50, -1)]
        [InlineData(0, 50, -0.111)]
        public void FromHSV_WhenInputValueIsOutOfRange_ThrowOutOfRangeArgumentException(double h, double s, double v)
        {
            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ColorConverter.FromHSV(h, s, v));
        }
    }
}
