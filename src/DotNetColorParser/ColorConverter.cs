using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DotNetColorParser
{
    public static class ColorConverter
    {

        const string outOfRangeExMsg = "Value has to be greater than or equal to {0} and less than or equal to {1}.";

        /// <summary>
        /// Convert color write in hexadecimal notation to <see cref="System.Drawing.Color"/>Color</see> object.
        /// </summary>
        /// <param name="hexColor">String containing color, i.e.: <example>FFFFFF</example>, <example>#ee0054</example>, <example>#eee</example>.</param>
        /// <returns>Color write in ARGB color space.</returns>
        public static Color FromHex(string hexColor)
        {
            var argumentExMsg = $"'{nameof(hexColor)}' cannot be null or whitespace.";

            if (hexColor is null)
            {
                throw new ArgumentException(argumentExMsg, nameof(hexColor));
            }

            var hexStr = hexColor.Trim().TrimStart('#');

            if (string.IsNullOrWhiteSpace(hexStr))
            {
                throw new ArgumentException(argumentExMsg, nameof(hexColor));
            }

            try
            {
                int value = Convert.ToInt32(hexStr, 16);

                if (hexStr.Length == 3)
                {
                    var wideValue = ((value & 0xF00) << 8) | ((value & 0x0F0) << 4) | (value & 0x00F);
                    value = wideValue | (wideValue << 4);
                }

                if (hexStr.Length == 4)
                {
                    var wideValue = ((value & 0xF000) << 12) | ((value & 0x0F00) << 8) | ((value & 0x00F0) << 4) | (value & 0x000F);
                    value = wideValue | (wideValue << 4);
                }

                if (hexStr.Length == 6 || hexStr.Length == 3)
                {
                    return Color.FromArgb(
                        (byte)((value >> 16) & 255),
                        (byte)((value >> 8) & 255),
                        (byte)(value & 255)
                    );
                }

                if (hexStr.Length == 8 || hexStr.Length == 4)
                {
                    return Color.FromArgb(
                        (byte)(value & 255),
                        (byte)((value >> 24) & 255),
                        (byte)((value >> 16) & 255),
                        (byte)((value >> 8) & 255)
                    );
                }

                throw new ArgumentException("String value has not correct length.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("String value is not a correct hexadecimal color value.", nameof(hexColor), ex);
            }
        }

        /// <summary>
        /// Convert color from CMYK color space to <see cref="System.Drawing.Color"/>Color</see> object.
        /// </summary>
        /// <param name="cyan">Cyan channel expressed as a percentage.</param>
        /// <param name="magenta">Magenta channel expressed as a percentage.</param>
        /// <param name="yellow">Yellow channel expressed as a percentage.</param>
        /// <param name="black">Black channel expressed as a percentage.</param>
        /// <returns>Color write in ARGB color space.</returns>
        public static Color FromCMYK(double cyan, double magenta, double yellow, double black)
        {
            if (cyan < 0 || cyan > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(cyan), string.Format(outOfRangeExMsg, 0, 100));
            }

            if (magenta < 0 || magenta > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(magenta), string.Format(outOfRangeExMsg, 0, 100));
            }

            if (yellow < 0 || yellow > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(yellow), string.Format(outOfRangeExMsg, 0, 100));
            }

            if (black < 0 || black > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(black), string.Format(outOfRangeExMsg, 0, 100));
            }

            double red = Math.Round(255.0 * (1.0 - cyan * 0.01) * (1.0 - black * 0.01), MidpointRounding.AwayFromZero);
            double geen = Math.Round(255.0 * (1.0 - magenta * 0.01) * (1.0 - black * 0.01), MidpointRounding.AwayFromZero);
            double blue = Math.Round(255.0 * (1.0 - yellow * 0.01) * (1.0 - black * 0.01), MidpointRounding.AwayFromZero);

            return Color.FromArgb((int)red, (int)geen, (int)blue);
        }

        /// <summary>
        /// Convert color from HSV color space to <see cref="System.Drawing.Color"/>Color</see> object.
        /// </summary>
        /// <param name="hue">Hue channel expressed as a degrees.</param>
        /// <param name="saturation">Saturation channel expressed as a percentage.</param>
        /// <param name="value">Value channel expressed as a percentage.</param>
        /// <returns>Color write in ARGB color space.</returns>
        public static Color FromHSV(double hue, double saturation, double value)
        {
            if (hue < 0 || hue > 360)
            {
                throw new ArgumentOutOfRangeException(nameof(hue), string.Format(outOfRangeExMsg, 0, 360));
            }

            if (saturation < 0 || saturation > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation), string.Format(outOfRangeExMsg, 0, 100));
            }

            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), string.Format(outOfRangeExMsg, 0, 100));
            }

            var normalizeValue = value / 100.0;
            var normailzeSaturation = saturation / 100.0;
            if (normailzeSaturation == 0.0)
            {
                var byteValue = (int)Math.Round(normalizeValue * 255, MidpointRounding.AwayFromZero);
                return Color.FromArgb(byteValue, byteValue, byteValue);
            }
            else if (normalizeValue == 0.0)
            {
                return Color.FromArgb(0, 0, 0);
            }
            else
            {
                /*
                 * HSV to RGB conversion formula
                 * When 0 ≤ H < 360, 0 ≤ S ≤ 1 and 0 ≤ V ≤ 1:
                 * C = V × S
                 * X = C × (1 - | (H / 60°) mod 2 - 1 |)
                 * m = V - C
                 * (R, G, B) = ((R'+m)×255, (G' + m)×255, (B'+m)×255)
                 */

                double red;
                double green;
                double blue;

                if (hue == 360)
                {
                    hue = 0;
                }
                var h = hue / 60d;
                var i = (int)Math.Floor(h);
                var c = normalizeValue * normailzeSaturation;
                var x = c * (1 - Math.Abs(h % 2 - 1));
                var m = normalizeValue - c;

                switch (i)
                {
                    case 0:
                        red = c;
                        green = x;
                        blue = 0;
                        break;
                    case 1:
                        red = x;
                        green = c;
                        blue = 0;
                        break;
                    case 2:
                        red = 0;
                        green = c;
                        blue = x;
                        break;
                    case 3:
                        red = 0;
                        green = x;
                        blue = c;
                        break;
                    case 4:
                        red = x;
                        green = 0;
                        blue = c;
                        break;
                    default:
                        red = c;
                        green = 0;
                        blue = x;
                        break;
                }


                return Color.FromArgb((int)Math.Round((red + m) * 255, MidpointRounding.AwayFromZero), (int)Math.Round((green + m) * 255, MidpointRounding.AwayFromZero), (int)Math.Round((blue + m) * 255, MidpointRounding.AwayFromZero));
            }
        }

        /// <summary>
        /// Convert color from HSL color space to <see cref="System.Drawing.Color"/>Color</see> object.
        /// </summary>
        /// <param name="hue">Hue channel expressed as a degrees.</param>
        /// <param name="saturation">Saturation channel expressed as a percentage.</param>
        /// <param name="lightness">Lightness channel expressed as a percentage.</param>
        /// <returns>Color write in ARGB color space.</returns>
        public static Color FromHSL(double hue, double saturation, double lightness)
        {

            if (hue < 0 || hue > 360)
            {
                throw new ArgumentOutOfRangeException(nameof(hue), string.Format(outOfRangeExMsg, 0, 360));
            }

            if (saturation < 0 || saturation > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation), string.Format(outOfRangeExMsg, 0, 100));
            }

            if (lightness < 0 || lightness > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(lightness), string.Format(outOfRangeExMsg, 0, 100));
            }

            if (hue == 360)
            {
                hue = 0;
            }
            var normalizeH = hue / 360.0;
            var normalizeS = saturation / 100.0;
            var normalizeL = lightness / 100.0;

            var q = (normalizeL < 0.5) ? normalizeL * (1.0 + normalizeS) : normalizeL + normalizeS - normalizeL * normalizeS;
            var p = 2.0 * normalizeL - q;

            double red = GetHue(p, q, normalizeH + 1.0 / 3.0);
            double geen = GetHue(p, q, normalizeH);
            double blue = GetHue(p, q, normalizeH - 1.0 / 3.0);

            return Color.FromArgb((int)Math.Round(red * 255, MidpointRounding.AwayFromZero), (int)Math.Round(geen * 255, MidpointRounding.AwayFromZero), (int)Math.Round(blue * 255, MidpointRounding.AwayFromZero));
        }

        /// <summary>
        /// Convert color from HSL color space with Alpha channel to <see cref="System.Drawing.Color"/>Color</see> object.
        /// </summary>
        /// <param name="hue">Hue channel expressed as a degrees.</param>
        /// <param name="saturation">Saturation channel expressed as a percentage.</param>
        /// <param name="lightness">Lightness channel expressed as a percentage.</param>
        /// <returns>Color write in ARGB color space.</returns>
        public static Color FromHSLA(double hue, double saturation, double lightness, double alpha)
        {
            if (alpha < 0 || alpha > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(alpha), string.Format(outOfRangeExMsg, 0, 1));
            }

            var baseColor = FromHSL(hue, saturation, lightness);

            return Color.FromArgb((int)Math.Round(alpha * 255, MidpointRounding.AwayFromZero), baseColor);
        }

        private static double GetHue(double p, double q, double t)
        {
            double value = p;

            if (t < 0) t++;
            if (t > 1) t--;

            if (t < 1.0 / 6.0)
            {
                value = p + (q - p) * 6.0 * t;
            }
            else if (t < 1.0 / 2.0)
            {
                value = q;
            }
            else if (t < 2.0 / 3.0)
            {
                value = p + (q - p) * (2.0 / 3.0 - t) * 6.0;
            }

            return value;
        }
    }
}
